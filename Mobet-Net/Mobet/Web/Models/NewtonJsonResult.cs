﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Mobet.Web.Models
{
    public class NewtonJsonResult : JsonResult
    {
        public NewtonJsonResult()
        {

        }
        public NewtonJsonResult(object data)
        {
            base.Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                //var jsonSerializerSettings = new JsonSerializerSettings
                //{
                //    //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                //   NullValueHandling = NullValueHandling.Include
                //};

                response.Write(JsonConvert.SerializeObject(Data, Formatting.Indented));
            }
        }
    }
}