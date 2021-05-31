using System;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using SimpleApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleApp.Dbcontext;
using SimpleApp.Controllers;

namespace EmailAuto
{

    public class EmailSender
    {
		private readonly IConfiguration _configuration;
		public EmailSender(IConfiguration configuration){
			_configuration=configuration;
		}
        private Tuple<string, string> getEmailContent(CandidateDetails candidate)
        {
            string candidateSubject = candidate.EmailID + " Candidate Applied ";
            StringBuilder stbCandidate = new StringBuilder();
            stbCandidate.Append("Email: " +(String.IsNullOrEmpty(candidate.EmailID) ? String.Empty : candidate.EmailID));
            stbCandidate.Append("Mobile: " +(String.IsNullOrEmpty(candidate.MobileNo) ? String.Empty : candidate.MobileNo.ToString()));
			stbCandidate.Append("Attendance: " +(String.IsNullOrEmpty(candidate.Attendance) ? String.Empty : candidate.Attendance));
			stbCandidate.Append("Message: " +(String.IsNullOrEmpty(candidate.Message) ? String.Empty : candidate.Message));
            return new Tuple<string, string>(candidateSubject, stbCandidate.ToString());
        }
        private Tuple<string, string> getEmailContent(MentorDetails mentor)
        {
            string mentorSubject = mentor.EmailID + " Mentor Applied ";
            StringBuilder stbMentor = new StringBuilder();
            stbMentor.Append("Email: " + (String.IsNullOrEmpty(mentor.EmailID) ? String.Empty : mentor.EmailID));
            stbMentor.Append("Attendance: " + (String.IsNullOrEmpty(mentor.Attendance) ? String.Empty : mentor.Attendance));
			stbMentor.Append("Resume: " + (String.IsNullOrEmpty(mentor.Resume) ? String.Empty : mentor.Resume));
			

            return new Tuple<string, string>(mentorSubject, stbMentor.ToString());
        }
        private Tuple<string, string> getEmailContent(BussinessDetails business)
        {
            string businessSubject = business.EmailID + " Business Applied ";
            StringBuilder stbBusiness = new StringBuilder();
            stbBusiness.Append("Email: " + (String.IsNullOrEmpty(business.EmailID) ? String.Empty : business.EmailID));
            stbBusiness.Append("Mobile: " + (String.IsNullOrEmpty(business.MobileNo) ? String.Empty : business.MobileNo));
			stbBusiness.Append("Subject: " + (String.IsNullOrEmpty(business.Subject) ? String.Empty : business.Subject));
			stbBusiness.Append("Message: " + (String.IsNullOrEmpty(business.Message) ? String.Empty : business.Message));
            return new Tuple<string, string>(businessSubject, stbBusiness.ToString());
        }
        private async Task sendEmail(string subject, string body)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("admin@brainchildschool.com", "Brainchildschool admin"),
                Subject = subject,
                PlainTextContent = body
            };
            msg.AddTo(new EmailAddress("brainchilddidactics@gmail.com", "Brainchild Administrator"));
            await client.SendEmailAsync(msg);
        }
        public void Send(CandidateDetails candidate)
        {
            var subjectBody = getEmailContent(candidate);
            sendEmail(subjectBody.Item1, subjectBody.Item2);

        }
        public void Send(MentorDetails mentor)
        {
            var subjectBody = getEmailContent(mentor);
            sendEmail(subjectBody.Item1, subjectBody.Item2);
        }
        public void Send(BussinessDetails business)
        {
            var subjectBody = getEmailContent(business);
            sendEmail(subjectBody.Item1, subjectBody.Item2);
        }
    }
}