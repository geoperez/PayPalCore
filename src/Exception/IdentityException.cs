using System.Text;
using PayPal.Api;

namespace PayPal
{
    /// <summary>
    /// Represents Identity API errors related to logging into PayPal securely using PayPal login credentials.
    /// <para>
    /// More Information: https://developer.paypal.com/webapps/developer/docs/api/#identity
    /// </para>
    /// </summary>
    public class IdentityException : HttpException
    {
        /// <summary>
        /// Gets a <see cref="PayPal.IdentityError"/> JSON object containing the parsed details of the Identity error.
        /// </summary>
        public IdentityError Details { get; private set; }

        /// <summary>
        /// Copy constructor that attempts to deserialize the response from the specified <seealso name="HttpException"/>.
        /// </summary>
        /// <param name="ex">Originating <see cref="PayPal.HttpException"/> object that contains the details of the exception.</param>
        public IdentityException(HttpException ex) : base(ex)
        {
            if (!string.IsNullOrEmpty(this.Response))
            {
                this.Details = JsonFormatter.ConvertFromJson<IdentityError>(this.Response);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("   Error:   " + this.Details.error);
                sb.AppendLine("   Message: " + this.Details.error_description);
                sb.AppendLine("   URI:     " + this.Details.error_uri);

                this.LogMessage(sb.ToString());
            }
        }

        /// <summary>
        /// Gets the prefix to use when logging the exception information.
        /// </summary>
        protected override string ExceptionMessagePrefix { get { return "Identity Exception"; } }
    }
}
