using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://localhost:55091/WebSite1/WebService.asmx")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    JavaScriptSerializer jss = new JavaScriptSerializer();
    ZIYARETCITAKIPOTOMASYONModel.ZIYARETCITAKIPOTOMASYONEntities kul = new ZIYARETCITAKIPOTOMASYONModel.ZIYARETCITAKIPOTOMASYONEntities();

   

   
     [WebMethod]
     public string getSelectUserItemLinq(int id)
     {
         
         string json = "";
         var gelenSorgu = kul.KULLANICIBILGILER.Where(x => x.KULLANICIID == id).Select(x=>x);
         //var gelenSorgu = kul.KULLANICIBILGILER.ToList();
         json = jss.Serialize(gelenSorgu);
         return json;
     }
     [WebMethod]
     public string getSelectUserItemIDLinq(string username,string userpass)
     {

         string json = "";
         var gelenSorgu = kul.KULLANICIBILGILER.Where(x=>x.KULLANICIEMAIL==username & x.KULLANICISIFRE==userpass).FirstOrDefault().KULLANICIID;
      
         json = jss.Serialize(gelenSorgu);
         return json;
     }

     [WebMethod]
     public string getDataAllLinq() {
         string json = "";
         var gelenSorgu = kul.KULLANICIYETKILENDIRME.ToList();
         json = jss.Serialize(gelenSorgu);
         return json;
     }

   
    
}
