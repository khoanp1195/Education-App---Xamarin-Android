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
    [Activity(Label = "UpdateTasks")]
    public class UpdateTasks : Activity
    {
        EditText titleTxt, contentTxt, subjectTxt, messageTxt, IdTxt;
        Button btnUpdate, btnGetId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UpdateTask);

            // Create your application here
            btnUpdate = (Button)FindViewById(Resource.Id.btnUpdate);
            btnGetId = (Button)FindViewById(Resource.Id.btnGetId);

            titleTxt = (EditText)FindViewById(Resource.Id.titleTxt);

            contentTxt = (EditText)FindViewById(Resource.Id.contentTxt);
            subjectTxt = (EditText)FindViewById(Resource.Id.subjectTxt);
            messageTxt = (EditText)FindViewById(Resource.Id.messageTxt);
            IdTxt = (EditText)FindViewById(Resource.Id.IdTxt);


            btnUpdate.Click += BtnUpdate_Click;

            btnGetId.Click += BtnGetId_Click;

     

        }

        private async void BtnGetId_Click(object sender, EventArgs e)
        {
            Tasks tasks = null;
            HttpClient client = new HttpClient();
            string url = $"https://education20220526152415.azurewebsites.net/api/Tasks" + IdTxt.Text.ToString();
            var result = await client.GetAsync(url);
            var json = await result.Content.ReadAsStringAsync();
            try
            {
                tasks = Newtonsoft.Json.JsonConvert.DeserializeObject<Tasks>(json);
            }
            catch(Exception ex)
            {

            }
            if(tasks ==null)
            {
                Toast.MakeText(this, json, ToastLength.Long).Show();
            }
            else
            {
                titleTxt = (EditText)tasks.Tittle;
                contentTxt = (EditText)tasks.ContentTask;
                subjectTxt = (EditText)tasks.Subject;
                messageTxt = (EditText)tasks.Message;


            }
          

        }

        async void BtnUpdate_Click(object sender, EventArgs e)
        {
            Tasks tasks = new Tasks();
            tasks.Tittle = titleTxt.Text;
            tasks.ContentTask = contentTxt.Text;
            tasks.Subject = subjectTxt.Text;
            tasks.Message = messageTxt.Text;
            HttpClient client = new HttpClient();
            string url = $"https://educationalapi.azurewebsites.net/api/Tasks/{tasks.Id}?Tittle={tasks.Tittle}&ContentTask={tasks.ContentTask}&Subject={tasks.Subject}&Message={tasks.Message}";
            var uri = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(tasks);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            response = await client.PostAsync(uri, content);
            Clear();
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                Toast.MakeText(this, "Your Task is Updated Success", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Your Task is Updated Failed", ToastLength.Long).Show();
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