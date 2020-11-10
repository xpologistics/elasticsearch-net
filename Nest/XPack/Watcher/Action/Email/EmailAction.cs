﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IEmailAction : IAction
	{
		[JsonProperty("account")]
		string Account { get; set; }

		[JsonProperty("attachments")]
		IEmailAttachments Attachments { get; set; }

		[JsonProperty("bcc")]
		IEnumerable<string> Bcc { get; set; }

		[JsonProperty("body")]
		IEmailBody Body { get; set; }

		[JsonProperty("cc")]
		IEnumerable<string> Cc { get; set; }

		[JsonProperty("from")]
		string From { get; set; }

		[JsonProperty("priority")]
		EmailPriority? Priority { get; set; }

		[JsonProperty("reply_to")]
		IEnumerable<string> ReplyTo { get; set; }

		[JsonProperty("subject")]
		string Subject { get; set; }

		[JsonProperty("to")]
		IEnumerable<string> To { get; set; }
	}

	public class EmailAction : ActionBase, IEmailAction
	{
		public EmailAction(string name) : base(name) { }

		public string Account { get; set; }
		public override ActionType ActionType => ActionType.Email;

		public IEmailAttachments Attachments { get; set; }

		public IEnumerable<string> Bcc { get; set; }

		public IEmailBody Body { get; set; }

		public IEnumerable<string> Cc { get; set; }

		public string From { get; set; }

		public EmailPriority? Priority { get; set; }

		public IEnumerable<string> ReplyTo { get; set; }

		public string Subject { get; set; }

		public IEnumerable<string> To { get; set; }
	}

	public class EmailActionDescriptor : ActionsDescriptorBase<EmailActionDescriptor, IEmailAction>, IEmailAction
	{
		public EmailActionDescriptor(string name) : base(name) { }

		protected override ActionType ActionType => ActionType.Email;

		string IEmailAction.Account { get; set; }
		IEmailAttachments IEmailAction.Attachments { get; set; }
		IEnumerable<string> IEmailAction.Bcc { get; set; }
		IEmailBody IEmailAction.Body { get; set; }
		IEnumerable<string> IEmailAction.Cc { get; set; }
		string IEmailAction.From { get; set; }
		EmailPriority? IEmailAction.Priority { get; set; }
		IEnumerable<string> IEmailAction.ReplyTo { get; set; }
		string IEmailAction.Subject { get; set; }
		IEnumerable<string> IEmailAction.To { get; set; }

		public EmailActionDescriptor Account(string account) => Assign(account, (a, v) => a.Account = v);

		public EmailActionDescriptor From(string from) => Assign(from, (a, v) => a.From = v);

		public EmailActionDescriptor To(IEnumerable<string> to) => Assign(to, (a, v) => a.To = v);

		public EmailActionDescriptor To(params string[] to) => Assign(to, (a, v) => a.To = v);

		public EmailActionDescriptor Cc(IEnumerable<string> cc) => Assign(cc, (a, v) => a.Cc = v);

		public EmailActionDescriptor Cc(params string[] cc) => Assign(cc, (a, v) => a.Cc = v);

		public EmailActionDescriptor Bcc(IEnumerable<string> bcc) => Assign(bcc, (a, v) => a.Bcc = v);

		public EmailActionDescriptor Bcc(params string[] bcc) => Assign(bcc, (a, v) => a.Bcc = v);

		public EmailActionDescriptor ReplyTo(IEnumerable<string> replyTo) => Assign(replyTo, (a, v) => a.ReplyTo = v);

		public EmailActionDescriptor ReplyTo(params string[] replyTo) => Assign(replyTo, (a, v) => a.ReplyTo = v);

		public EmailActionDescriptor Subject(string subject) => Assign(subject, (a, v) => a.Subject = v);

		public EmailActionDescriptor Body(Func<EmailBodyDescriptor, IEmailBody> selector) =>
			Assign(selector.InvokeOrDefault(new EmailBodyDescriptor()), (a, v) => a.Body = v);

		public EmailActionDescriptor Priority(EmailPriority? priority) => Assign(priority, (a, v) => a.Priority = v);

		public EmailActionDescriptor Attachments(Func<EmailAttachmentsDescriptor, IPromise<IEmailAttachments>> selector) =>
			Assign(selector, (a, v) => a.Attachments = v?.Invoke(new EmailAttachmentsDescriptor())?.Value);
	}
}
