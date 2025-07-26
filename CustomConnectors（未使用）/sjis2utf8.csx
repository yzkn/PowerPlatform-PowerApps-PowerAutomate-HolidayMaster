public class Script : ScriptBase
{
    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        HttpResponseMessage response;
        var contentAsString = await this.Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false);
        var contentAsJson = JObject.Parse(contentAsString);
        var text = (string)contentAsJson["text"];
        var encodingInput = (string)contentAsJson["encodingInput"] ?? "Shift_JIS";
        var encodingOutput = (string)contentAsJson["encodingOutput"] ?? "UTF-8";
        
        // System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        
        Encoding inputEncoding = null;
        Encoding outputEncoding = null;
        try
        {
            inputEncoding = Encoding.GetEncoding(name: encodingInput);
            outputEncoding = Encoding.GetEncoding(encodingOutput);

            JObject output = new JObject
            {
                ["text"] = Convert.ToBase64String(
                            Encoding.Convert(
                                srcEncoding: inputEncoding,
                                dstEncoding: outputEncoding,
                                bytes: Convert.FromBase64String(text)))
            };

            response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = CreateJsonContent(output.ToString());
            return response;
        }
        catch (ArgumentException e)
        {
            response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = CreateJsonContent(e.ToString());
            return response;
        }
    }
}
