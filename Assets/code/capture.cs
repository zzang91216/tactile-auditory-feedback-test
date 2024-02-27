using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class capture : MonoBehaviour
{
    UdpClient srv;
    IPEndPoint remoteEP;
    // Start is called before the first frame update
    void Start()
    {
        srv = new UdpClient(7777);
    }

    // Update is called once per frame
    void Update()
    {
        remoteEP = new IPEndPoint(IPAddress.Any, 0);

        while(true) {
            try{
                byte[] dgram = srv.Receive(ref remoteEP);
                var json_data = System.Text.Encoding.UTF8.GetString (dgram);
                Console.WriteLine("[Receive] {0} 로부터 {1} 바이트 수신", remoteEP.ToString(), dgram.Length);
            } catch (SocketException e) { }
        }
    }


}
