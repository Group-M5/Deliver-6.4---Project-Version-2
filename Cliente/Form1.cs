using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    public partial class Form1 : Form
    {
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el IP del servidor y puerto
            //del servidor al que queremos conectarnos

            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);

            //Creamos el socket

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                MessageBox.Show("Connected!");

                //Enviamos al servidor el nombre de usuario y contraseña
                byte[] username = System.Text.Encoding.ASCII.GetBytes(log_in_usrnme.Text + "/");
                server.Send(username);
                byte[] password = System.Text.Encoding.ASCII.GetBytes(log_in_psswrd.Text);
                server.Send(password);

                //Recibimos la respuesta del servidor
                byte[] err = new byte[80];
                server.Receive(err);

            }

            catch(SocketException ex)
            {
                MessageBox.Show("Couldn't reach server");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el IP del servidor y puerto
            //del servidor al que queremos conectarnos

            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);

            //Creamos el socket

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                MessageBox.Show("Connected!");

                //Enviamos al servidor el nombre de usuario y contraseña
                byte[] username = System.Text.Encoding.ASCII.GetBytes(reg_usrnme.Text + "/");
                server.Send(username);
                byte[] password = System.Text.Encoding.ASCII.GetBytes(reg_psswrd.Text);
                server.Send(password);

                //Recibimos la respuesta del servidor
                byte[] err = new byte[80];
                server.Receive(err);

           
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Couldn't reach server");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el IP del servidor y puerto
            //del servidor al que queremos conectarnos

            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);

            //Creamos el socket

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);

                if (MostMoves.Checked)
                {
                    string mensaje = "1/" + User1Box.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("La partida con mas movimientos de este jugador es: " + mensaje);
                }
                else if (CheckCards.Checked)
                {
                    string mensaje = "2/" + User2Box.Text + "/" + gameBox.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("Las cartas de este jugador son: " + mensaje);
                }
                else
                {
                    string mensaje = "3/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(mensaje);
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Couldn't reach server");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
