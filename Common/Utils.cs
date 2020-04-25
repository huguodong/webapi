using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Utils
    {

        public static HttpResponseMessage toJson(HttpStatusCode code, object result)
        {

            var response = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            HttpResponseMessage res = new HttpResponseMessage(code);
            res.Content = new StringContent(response, Encoding.UTF8, "application/json");
            return res;
        }

        public static Page GetPage(int pageIndex, int pageSize, int totalNumber, int totalPage)
        {
            Page page = new Page();
            page.is_first_page = pageIndex == 1 ? true : false;
            page.is_last_page= pageIndex == totalPage ? true : false;
            page.page_no = pageIndex;
            page.page_size = pageSize;
            page.total_count = totalNumber;
            page.total_page = totalPage;
            return page;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("1");
        }
    }
}
