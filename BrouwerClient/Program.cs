using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrouwerClient
{
    class Program
    {
        static async Task Main() 
        {

            //====================================================================
            // CODE GET: GET/READ SINGLE ROW FROM CLIENT SIDE
            //=====================================================================

            //Console.Write("Id:"); 
            //var id = int.Parse(Console.ReadLine()); 
            //using var client = new HttpClient(); 
            //var response = await client.GetAsync($"http://localhost:5000/brouwers/{id}"); 
            //switch (response.StatusCode) 
            //{ 
            //    case HttpStatusCode.OK:       var brouwer = await response.Content.ReadAsAsync<Brouwer>(); 
            //                                  Console.WriteLine(brouwer.Naam); 
            //                                  break; 
            //    case HttpStatusCode.NotFound: Console.WriteLine("Brouwer niet gevonden"); 
            //                                  break; 
            //    default:                      Console.WriteLine("Technisch probleem, contacteer de helpdesk."); 
            //                                  break; 
            //}

            //=============================================================
            //END OF CODE GET : GET/READ SINGLE ROW FROM CLIENT SIDE
            //==============================================================

            //====================================================================
            // CODE GET : GET/READ MULTIPLE ROWS FROM CLIENT SIDE
            //=====================================================================

            //Console.Write("Druk enter om de namen te zien"); 
            //Console.ReadLine();
            //using var client = new HttpClient();
            //var response = await client.GetAsync($"http://localhost:5000/brouwers");
            //switch (response.StatusCode)
            //{
            //    case HttpStatusCode.OK:         var brouwers = await response.Content.ReadAsAsync<List<Brouwer>>();
            //                                    brouwers.ForEach(brouwer => Console.WriteLine(brouwer.Naam));                    
            //                                    break;
            //    case HttpStatusCode.NotFound:   Console.WriteLine("Brouwer niet gevonden");
            //                                    break;
            //    default:                        Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
            //                                    break;
            //}

            //===================================================================================
            //END OF CODE GET : GET/READ MULTIPLE ROWS FROM CLIENT SIDE
            //===================================================================================

            //==================================================================================
            // CODE GET : GET/READ ROWS FROM CLIENT SIDE WHERE NAME BEGINS WITH SOME TEXT
            //===================================================================================

            //Console.Write("Begin van de naam:");
            //var begin = Console.ReadLine();
            //using var client = new HttpClient();
            //var response = await client.GetAsync($"http://localhost:5000/brouwers/naam?begin={begin}");
            //switch (response.StatusCode)
            //{
            //    case HttpStatusCode.OK:         var brouwers = await response.Content.ReadAsAsync<List<Brouwer>>();
            //                                    brouwers.ForEach(brouwer => Console.WriteLine(brouwer.Naam));
            //                                    break;
            //    case HttpStatusCode.NotFound:   Console.WriteLine("Brouwer niet gevonden");
            //                                    break;
            //    default:                        Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
            //                                    break;
            //}

            //===================================================================================
            //END OF CODE GET : GET/READ ROWS FROM CLIENT SIDE WHERE NAME BEGINS WITH SOME TEXT
            //===================================================================================

            //====================================================================
            // CODE POST : ADD ROW FROM CLIENT SIDE
            //=====================================================================

            //var brouwer = new Brouwer(); 

            //Console.Write("Naam:"); 
            //brouwer.Naam = Console.ReadLine(); 

            //Console.Write("Postcode:"); 
            //brouwer.Postcode = int.Parse(Console.ReadLine()); 

            //Console.Write("Gemeente:"); 
            //brouwer.Gemeente = Console.ReadLine(); 

            //using var client = new HttpClient(); 
            //var response = await client.PostAsJsonAsync("http://localhost:5000/brouwers", brouwer); 
            ////var response = await client.PostAsXmlAsync("http://localhost:5000/brouwers", brouwer);
            //if (response.StatusCode == HttpStatusCode.Created) 
            //{ 
            //    Console.WriteLine($"Brouwer is toegevoegd. Zijn URI is {response.Headers.Location}"); 
            //} 
            //else 
            //{ 
            //    Console.WriteLine("Technisch probleem, contacteer de helpdesk."); 
            //}       


            //====================================================================
            // END OF CODE POST : ADD ROW FROM CLIENT SIDE
            //=====================================================================

            //====================================================================
            // CODE PUT : CHANGE ROW DATA FROM CLIENT SIDE
            //=====================================================================

            Console.Write("Id:"); 
            var id = int.Parse(Console.ReadLine());

            using var client = new HttpClient(); 
            //var client = clientFactory.CreateClient();
            var uri = $"http://localhost:5000/brouwers/{id}"; 

            var response = await client.GetAsync(uri); 
            
            switch (response.StatusCode) 
            { 
                case HttpStatusCode.OK:         var brouwer = await response.Content.ReadAsAsync<Brouwer>(); 
                                                brouwer.Gemeente = brouwer.Gemeente.ToUpper(); 
                                                response = await client.PutAsJsonAsync(uri, brouwer);
                                                //response = await client.PostAsXmlAsync(uri, brouwer);       
                                                if (response.StatusCode == HttpStatusCode.OK) 
                                                {
                                                    Console.WriteLine("Brouwer gewijzigd");
                                                } 
                                                else 
                                                {
                                                    Console.WriteLine("Technisch probleem, contacteer de helpdesk."); 
                                                } 
                                                break; 
                case HttpStatusCode.NotFound:   Console.WriteLine("Brouwer niet gevonden");
                                                break; 
                default:                        Console.WriteLine("Technisch probleem, contacteer de helpdesk."); 
                                                break; 
            }


            //====================================================================
            // END OF CODE PUT : CHANGE ROW DATA FROM CLIENT SIDE
            //=====================================================================

            //====================================================================
            // CODE DELETE: DELETE OPERATION  FROM CLIENT SIDE
            //=====================================================================

            //Console.Write("Id:");   
            //var id = int.Parse(Console.ReadLine());  
            //using var client = new HttpClient(); 
            //var response = await client.DeleteAsync($"http://localhost:5000/brouwers/{id}"); 
            //switch (response.StatusCode) 
            //{      
            //    case HttpStatusCode.OK:         Console.WriteLine("Brouwer is verwijderd."); 
            //                                    break;         
            //    case HttpStatusCode.NotFound:   Console.WriteLine("Brouwer niet gevonden");          
            //                                    break;        
            //    default:                        Console.WriteLine("Technisch probleem, contacteer de helpdesk."); 
            //                                    break;      
            //}    

            //=============================================================
            //END OF CODE DELETE: DELETE OPERATION FROM CLIENT SIDE
            //==============================================================
        }
    }
}
