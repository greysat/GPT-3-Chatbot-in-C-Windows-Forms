using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string prompt = textBox1.Text;

        var httpClient = new HttpClient();
        var apiKey = "";
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

        var content = new StringContent("{\"messages\":[{\"role\":\"system\",\"content\":\"You are a helpful assistant.\"},{\"role\":\"user\",\"content\":\"" + prompt + "\"}]}", System.Text.Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://api.openai.com/v1/completions", content);

        var data = await response.Content.ReadAsStringAsync();

        var parsed = JObject.Parse(data);

        if (parsed["choices"] != null && parsed["choices"].HasValues)
        {
            richTextBox1.Text = parsed["choices"][0]["message"]["content"].ToString();
        }
        else
        {
            richTextBox1.Text = "No response from API";
        }
    }
}
https://images.openai.com/blob/557a9f70-0bf6-4d72-91c6-5bc5423ad462/stangel-2022-0602.jpg?trim=90,0,630,0&width=2600