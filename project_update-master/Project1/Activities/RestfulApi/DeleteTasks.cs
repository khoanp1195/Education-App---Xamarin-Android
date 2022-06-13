using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Project1.Activities.RestfulApi
{
    [Activity(Label = "DeleteTasks")]
    public class DeleteTasks : Activity
    {
        EditText titleTxt, contentTxt, subjectTxt, messageTxt, IdTxt;
        Button btndelete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.deleteTasks);

            // Create your application here


            
            btndelete = (Button)FindViewById(Resource.Id.btnDelete);
            titleTxt = (EditText)FindViewById(Resource.Id.titleTxt);
            contentTxt = (EditText)FindViewById(Resource.Id.contentTxt);
            subjectTxt = (EditText)FindViewById(Resource.Id.subjectTxt);
            messageTxt = (EditText)FindViewById(Resource.Id.messageTxt);
            IdTxt = (EditText)FindViewById(Resource.Id.IdTxt);


            btndelete.Click += Btndelete_Click;
          

        }

        async void Btndelete_Click(object sender, EventArgs e)
        {
           Tasks tasks = new Tasks();
            tasks.Id = IdTxt.Text;
            HttpClient client = new HttpClient();

            string url = "https://educationalapi.azurewebsites.net/api/Tasks/" + IdTxt.Text.ToString();
            var uri = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(tasks);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            response = await client.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                Toast.MakeText(this, "Your Task is Deleted Success", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Your Task is Deleted Failed", ToastLength.Long).Show();
            }


        }
    }
}