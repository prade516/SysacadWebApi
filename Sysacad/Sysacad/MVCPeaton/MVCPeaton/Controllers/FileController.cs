using HalClient.Net;
using HalClient.Net.Parser;
using MVCPeaton.Security;
using MVCPeaton.Tools.Exceptions;
using MVCPeaton.Tools.Misc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPeaton.Controllers
{
    public class FileController : Controller
    {
        MVCPeaton.Tools.Misc.FileResult fr;
        public DataValues Decode()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                throw new NotImplementedException();
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            DataValues md = JsonConvert.DeserializeObject<DataValues>(authTicket.UserData);
            return md;
        }

        private static IHalJsonParser parser;
        private static IHalHttpClientFactory factory;



        private static IHalJsonParser Parser
        {
            get
            {
                if (parser == null)
                    parser = new HalJsonParser();
                return parser;
            }

            set
            {
                parser = value;
            }
        }

        public static IHalHttpClientFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = new HalHttpClientFactory(Parser);
                return factory;
            }

            set
            {
                factory = value;
            }
        }


        #region UploadsPrivate
        [Authorize]
        [HttpPost]
        public JsonResult UploadPrivatePhoto()
        {
            String filePath = String.Empty;
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.InputStream), "\"file\"", string.Format("\"{0}\"", file.FileName)
                );

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/PrivatePicture"), content)
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult UploadPrivateDocument()
        {
            String filePath = String.Empty;
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.InputStream), "\"file\"", string.Format("\"{0}\"", file.FileName)
                );

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/PrivateDocument"), content)
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult UploadPrivateSpreedSheet()
        {
            String filePath = String.Empty;
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.InputStream), "\"file\"", string.Format("\"{0}\"", file.FileName)
                );

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/PrivateSpreedsheet"), content)
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region DownloadsPrivate
        [Authorize]
        [HttpPost]
        public JsonResult DownloadPrivatePhoto(Qualitiers qual,string localFilePath)
        {
            String filePath = String.Empty;
            try
            {
                //Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
                MVCPeaton.Tools.Misc.FileResult fileresult = new MVCPeaton.Tools.Misc.FileResult()
                {
                    LocalFilePath = localFilePath
                 ,
                    Qualitier = qual
                };
                string postBody = JsonConvert.SerializeObject(fileresult);
                byte[] a = null;
                string ard = "";
                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/DownloadPrivatePicture"), new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    a = response.Content.ReadAsByteArrayAsync().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                {

                    using (MemoryStream ms = new MemoryStream(a))
                    {

                        ard = Convert.ToBase64String(ms.ToArray());
                    }
                }


                return Json(new { Success = true, Result = ard }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult DownloadPrivateDocument(Qualitiers qual, string localFilePath)
        {
            String filePath = String.Empty;
            try
            {
                //Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
                MVCPeaton.Tools.Misc.FileResult fileresult = new MVCPeaton.Tools.Misc.FileResult()
                {
                    LocalFilePath = localFilePath
                 ,
                    Qualitier = qual
                };
                string postBody = JsonConvert.SerializeObject(fileresult);

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/DownloadPrivateDocument"), new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult DownloadPrivateSpreedsheet(Qualitiers qual, string localFilePath)
        {
            String filePath = String.Empty;
            try
            {
                //Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
                MVCPeaton.Tools.Misc.FileResult fileresult = new MVCPeaton.Tools.Misc.FileResult()
                {
                    LocalFilePath = localFilePath
                 ,
                    Qualitier = qual
                };
                string postBody = JsonConvert.SerializeObject(fileresult);

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/DownloadPrivateSpreedSheet"), new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion


        #region UploadsPublic
        //[Authorize]
        [HttpPost]
        public JsonResult UploadPublicPhoto()
        {
            String filePath = String.Empty;
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.InputStream), "\"file\"", string.Format("\"{0}\"", file.FileName)
                );

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/PublicPicture"), content)
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult UploadPublicDocument()
        {
            String filePath = String.Empty;
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.InputStream), "\"file\"", string.Format("\"{0}\"", file.FileName)
                );

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/PublicDocument"), content)
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult UploadPublicSpreedSheet()
        {
            String filePath = String.Empty;
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.InputStream), "\"file\"", string.Format("\"{0}\"", file.FileName)
                );

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/PublicSpreedsheet"), content)
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region DownloadsPublic
        //[Authorize]
        [HttpPost]
        public JsonResult DownloadPublicPhoto(Qualitiers qual, string localFilePath)
        {
            String filePath = String.Empty;
            try
            {
                //Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
                MVCPeaton.Tools.Misc.FileResult fileresult = new MVCPeaton.Tools.Misc.FileResult()
                {
                    LocalFilePath = localFilePath
                 ,
                    Qualitier = qual
                };
                string postBody = JsonConvert.SerializeObject(fileresult);
                byte[] a=null;
                string ard = "";
                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/DownloadPublicPicture"), new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    a = response.Content.ReadAsByteArrayAsync().Result;
                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                { 
                    
                    using (MemoryStream ms = new MemoryStream(a))
                    {

                        ard= Convert.ToBase64String(ms.ToArray());
                     }
                }


                return Json(new { Success = true, Result=ard }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception();
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                //return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult DownloadPublicDocument(Qualitiers qual, string localFilePath)
        {
            String filePath = String.Empty;
            try
            {
                //Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
                MVCPeaton.Tools.Misc.FileResult fileresult = new MVCPeaton.Tools.Misc.FileResult()
                {
                    LocalFilePath = localFilePath
                 ,
                    Qualitier = qual
                };
                string postBody = JsonConvert.SerializeObject(fileresult);

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/DownloadPublicDocument"), new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }

        
        [HttpPost]
        public JsonResult DownloadPublicSpreedsheet(Qualitiers qual, string localFilePath)
        {
            String filePath = String.Empty;
            try
            {
                //Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
                MVCPeaton.Tools.Misc.FileResult fileresult = new MVCPeaton.Tools.Misc.FileResult()
                {
                    LocalFilePath = localFilePath
                 ,
                    Qualitier = qual
                };
                string postBody = JsonConvert.SerializeObject(fileresult);

                bool success = false;
                string result;
                HttpStatusCode code;
                using (var client = Factory.CreateClient())
                {
                    client.HttpClient.DefaultRequestHeaders.Clear();
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                    if (User.Identity.IsAuthenticated)
                    {
                        DataValues datavalue = Decode();
                        client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", datavalue.Token);
                    }
                    Task taskDownload = client.HttpClient.PostAsync((ConfigurationResolver.filesUrl + "/DownloadPublicSpreedSheet"), new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .ContinueWith(task =>
                        {
                            if (task.Status == TaskStatus.RanToCompletion)
                            {
                                var response = task.Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    success = true;
                                    code = response.StatusCode;
                                    fr = JsonConvert.DeserializeObject<MVCPeaton.Tools.Misc.FileResult>
                                    (response.Content.ReadAsAsync<string>().Result);
                                    //result = response.Content.ReadAsAsync<string>().Result;

                                }
                                else
                                {
                                    code = response.StatusCode;

                                }
                            }
                        });
                    taskDownload.Wait();

                }
                if (success)
                    return Json(new { Success = true, Result = fr.FileName, Path = fr.LocalFilePath }, JsonRequestBehavior.AllowGet);
                throw new Exception();
            }
            catch (Exception ex)
            {
                HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                return Json(new { Success = false, Result = "Mal" }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
        public ActionResult TestUpload()
        {
            return View();
        }

        public ActionResult TestDownload()
        {
            return View();
        }
    }
}