using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using DevExpress.Web;
using MvcApp_Q398100.Models;

public static class NorthwindDataProvider {
    static NorthwindDataContext db;
    public static NorthwindDataContext DB {
        get {
            if (db == null)
                db = new NorthwindDataContext();
            return db;
        }
    }
    public static IEnumerable GetProducts() {
        return from product in DB.Products select product;
    }
}
