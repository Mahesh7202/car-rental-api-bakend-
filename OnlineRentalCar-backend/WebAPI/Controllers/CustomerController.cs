using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System;
using WebAPI.Helper;
using WebAPI.Service;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Entities.Concrete;
using MimeDetective.Storage.Xml.v2;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Runtime.ConstrainedExecution;
using System.Net.Mail;
using System.Collections;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IEmailService emailService;
        public CustomerController(IEmailService service)
        {
            this.emailService = service;
        }



        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail([FromBody] BookingData requestData)
        {
            Trace.WriteLine("This is a trace message.0000000000000000000000000000000000000000000000000000000000");

            try
            {
                Mailrequest mailrequest = new Mailrequest();
                Mailrequest mailrequest2 = new Mailrequest(); 
                var user = requestData.User;


                mailrequest.ToEmail = user.Email;
                mailrequest.Subject = "Welcome to Car Rental";
                mailrequest.Body = GetHtmlContent(requestData);   

                mailrequest2.ToEmail = user.Email;
                mailrequest2.Subject = "Review for Car Rental";
                mailrequest2.Body = GetHtmlContent2(requestData);
                
                await emailService.SendEmailAsync(mailrequest);
                await emailService.SendEmailAsync(mailrequest2);
                return Ok();
            }
            catch (SmtpException smtpEx)
            {
                Trace.WriteLine("SMTP error sending email: {ErrorMessage}", smtpEx.Message);
                // Handle the SMTP-specific error
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error sending email: {ErrorMessage}", ex.Message);
                // Handle other exceptions
            }
            return BadRequest();

        }

        private string GetHtmlContent2(BookingData requestData ) {
      var user = requestData.User;
      var carDetailsArray = requestData.CarDetails;
      var orderData = requestData.OrderData;


      StringBuilder linksForEachCarHtml = new StringBuilder();

      foreach(var carDetails in carDetailsArray)
      {
        linksForEachCarHtml.AppendLine($@"
              <a class=""btn btn-primary""
                  style=""padding: 10px 20px; font-size: 18px; border-radius: 5px; background-color: #007bff; color: white;""
                  href=""http://localhost:4200/review/{user.Id}/{carDetails.Car.Id}"">
                  <b>Review For Car: {carDetails.Car.BrandName}</b>
               </a>
              ");
      }



      string htmlContent = $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Car Rental Confirmation</title>
    <style>
        body {{
            background-color: black;
            color: white;
            text-align: center;
        }}
        h1 {{
            margin-top: 100px;
        }}
            
	img {{
       display: block;
        height: 200px;
        width: 200px;
    }}
        table {{
            margin: 20px auto;
            border-collapse: collapse;
            width: 80%;
        }}
        th, td {{
            padding: 10px;
            border: 1px solid white;
        }}
        th {{
            background-color: #333;
            color: white;
            font-weight: bold;
        }}
        th, td {{
            text-align: left;
        }}
        .additional-info {{
            margin-top: 20px;
        }}
    </style>
</head>
<body>
    <h1>Car Rental Feedback</h1>
    <img src=""https://static.sitejabber.com/img/urls/974466/picture_110314.1557907189.jpg"" style=""box-shadow: 0px 0px 10px blue;"" alt=""Car Rental Logo"" width=""150"">
    <p>Thanks for choosing us!</p>
<p>please provide us with you feed baack</p>
<p><b>note:</b> Click on the review link to givee your Feedback</p>

{linksForEachCarHtml.ToString()}

</button>

</body>
</html>
";
      return htmlContent;

    }
        private string GetHtmlContent(BookingData requestData)
        {
            Trace.WriteLine("This is a trace message.11111111111111111111111111111111111111111111111111111111111111");
            var user = requestData.User;
            var carDetailsArray = requestData.CarDetails;
            var orderData = requestData.OrderData;

            Trace.WriteLine("This is a trace message.33333333333333333333333333333333333333333333333333333333333333333333");
            Trace.WriteLine(carDetailsArray.Count);


            StringBuilder carDetailsHtml = new StringBuilder();
      StringBuilder rentDetailsHtml = new StringBuilder();

      


      foreach (var carDetails in carDetailsArray)
      {
        carDetailsHtml.AppendLine($@"
        <table style='margin: 20px auto; border-collapse: collapse; width: 80%;'>
            <tr>
                <th>Car Details</th>  
                <th>Booking Details</th>       
            </tr>        
            <tr>       
                <td style='padding: 10px; border: 1px solid white;'>
                    Car ID: {carDetails.Car.Id}<br>
                    Car Brand: {carDetails.Car.BrandName}<br>
                    Car Model: {carDetails.Car.ModelName}<br>
                    Car Description: {carDetails.Car.Description}<br>
                    Daily price: {carDetails.Car.DailyPrice}
                </td>
                <td style='padding: 10px; border: 1px solid white;'>
                    Booking ID: {orderData.PaymentId + carDetails.Car.Id}<br>
                    LeasedDay: {orderData.TotalRentalDays}<br>
                    Daily Fee: {carDetails.Car.DailyPrice}<br>
                    Total Amount: {orderData.TotalAmount}
                </td>       
            </tr>   
        </table>"
        );

        rentDetailsHtml.AppendLine($@"
        <table style='margin: 20px auto; border-collapse: collapse; width: 80%;'>
            <tr>
              <th colspan=""2"" style=""text-align: center"">Rental date</th>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid white;'>
                    Start Date: {carDetails.RentDate}<br>
                </td>
                <td style='padding: 10px; border: 1px solid white;'>
                    End Date: {carDetails.ReturnDate}
                </td>
            </tr>
        </table>"
        );
      }



      string htmlContent = $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Car Rental Confirmation</title>
    <style>
        body {{
            background-color: black;
            color: white;
            text-align: center;
        }}

            
	img {{
       display: block;
        height: 200px;
        width: 200px;
    }}
        h2{{
            text-align: center; 
        }}

        table {{
            margin: 20px auto;
            border-collapse: collapse;
            width: 80%;
        }}
        th, td {{
            padding: 10px;
            border: 1px solid white;
        }}
        th {{
            background-color: #333;
            color: white;
            font-weight: bold;
        }}
        th, td {{
            text-align: left;
        }}
        .additional-info {{
            margin-top: 20px;
        }}
    </style>
</head>
<body>
       <h1 style=""text-align: center;"">Welcome to Car Rental</h1>
    <img src=""https://img.freepik.com/free-vector/green-eco-loop-leaf-check-mark_78370-658.jpg?w=740&t=st=1695112817~exp=1695113417~hmac=a1014a53b770e86ef353c00507122a38f6ea0c0142189dcec165f1f125e2170a""
         style=""display: block; margin: 0 auto; box-shadow: 0px 0px 10px blue;""
         alt=""Car Rental Logo"" width=""150"">
    <h2 style=""text-align: center;"">Booking Successful!</h2>
<p style=""text-align: center;"">Thanks for choosing us!</p>

   {carDetailsHtml.ToString()}
<p style=""text-align: center;""><b>Rental and Payment Details<b><p>
       
{rentDetailsHtml.ToString()}
     

    <table>

<th>Payment Details</th>
<th>Contact Information:</th>
</tr>
<tr>
            <td>Payment ID: {orderData.PaymentId}<br>
		Payment Date: {orderData.RentalDate}	<br>
		Number of Total Rented Cras: {orderData.NumberOfTotalRentedCar}<br>
		Total Rented Days: {orderData.TotalRentalDays}<br>
		Rental Date : {orderData.RentalDate}
		</td>
	    <td>Customer ID: {user.Id}<br>
		Email Id: {user.Email}<br></td>

</tr>
    </table>



    <div class=""additional-info"">
        <p>Additional Notes.</p>
<p>Please review the above information to ensure accuracy. If you have any questions or need further assistance, please do not hesitate to contact our customer support team at [Customer Support Email or Phone Number].

We look forward to serving you, and we hope you have a wonderful experience with us.

Thank you for choosing CAR Rental!</p>
    </div>
</body>
</html>
";


            return htmlContent;
        }
    }

}
