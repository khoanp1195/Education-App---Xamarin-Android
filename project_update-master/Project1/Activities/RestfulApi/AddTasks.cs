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
using System.Net.Http.Headers;
using System.Text;

namespace Project1.Activities.RestfulApi
{
    [Activity(Label = "AddTasks")]
    public class AddTasks : Activity
    {
        EditText titleTxt, contentTxt, subjectTxt, messageTxt;
        Button btnAdd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addTasks);

            // Create your application here


            btnAdd = (Button)FindViewById(Resource.Id.btnAdd);
            titleTxt = (EditText)FindViewById(Resource.Id.titleTxt);
            contentTxt = (EditText)FindViewById(Resource.Id.contentTxt);
            subjectTxt = (EditText)FindViewById(Resource.Id.subjectTxt);
            messageTxt = (EditText)FindViewById(Resource.Id.messageTxt);


            btnAdd.Click += BtnAdd_Click;
        }

        async void BtnAdd_Click(object sender, EventArgs e)
        {
            Tasks tasks = new Tasks();
            tasks.Tittle = titleTxt.Text;
            tasks.ContentTask= contentTxt.Text;
            tasks.Subject= subjectTxt.Text;
            tasks.Message = messageTxt.Text;
            HttpClient client = new HttpClient();
            string url = "https://educationalapi.azurewebsites.net/api/Tasks?Tittle={tasks.Tittle}&ContentTask={tasks.ContentTask}&Subject={tasks.Subject}&Message={tasks.Message}";
            var uri = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(tasks);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            response = await client.PostAsync(uri, content);
            Clear();
            if(response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                Toast.MakeText(this, "Your Task is Added Success", ToastLength.Long).Show();   
            }
            else
            {
                Toast.MakeText(this, "Your Task is Added Failed", ToastLength.Long).Show();
            }


           
        }

        void Clear()
        {
            titleTxt.Text = " ";
            contentTxt.Text = " ";
            subjectTxt.Text = " ";
            messageTxt.Text = " ";
        }
    }
}