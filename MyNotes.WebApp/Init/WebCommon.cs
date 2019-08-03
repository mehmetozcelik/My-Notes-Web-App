using MyNotes.Common;
using MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNotes.WebApp.Init
{
    // User kayıt olurken 'ModifiedUser' alanın doldurulması. Ya Sesison'daki user bilgisi yada default 'system' ibaresi. 
    
    public class WebCommon : ICommon
    {        
        public string GetCurrentUsername()
        {
            if (HttpContext.Current.Session["login"] != null)
            {
                MyNotesUser user = (MyNotesUser) HttpContext.Current.Session["login"];
                return user.Username;
            }          
            
            return "system";
        }
    }
}