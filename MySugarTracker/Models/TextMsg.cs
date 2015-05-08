using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio.Mvc;
using Twilio;
using Twilio.Model;
using Twilio.TwiML.Mvc;
using Twilio.TwiML.Verbs;

namespace MySugarTracker.Models
{
    public class TextMsg
    {
        public string SendMessage(string message, string toNumber)
        {
            string AcctSid = "ACb54ced82a92ac0505182ce01b10c6210";
            string AcctToken = "48b80f57b04119bc8bfe92c52ec650a8";
            string phoneFrom = "+12695584756";

            string phoneTo = "+1" + toNumber;

            var TwClient = new TwilioRestClient(AcctSid, AcctToken);
            var errMessage = TwClient.SendMessage(phoneFrom, phoneTo, message);

            if ((errMessage != null) && (errMessage.RestException != null))
            {
                var error = errMessage.RestException.Message;
                return error;
            }
            else
                return "";
        }
    }
}