using Nancy;
using Nancy.ModelBinding;
using NancyDemoProgressiveNet.Models;

namespace NancyDemoProgressiveNet._03Request
{
    public class FormTestModule : NancyModule
    {
        private const string INSULT_TO_HONORABLE_PEOPLE = "Wow, you're an old guy, {0}!";
        private const string NICE_RESPECTABLE_ANSWER = "Still in your prime! Keep it up, {0}!";

        public FormTestModule()
        {
            Post["/areYouOld"] = p =>
            {
                var person = this.Bind<Person>();
                return string.Format(person.Age > 39
                    ? INSULT_TO_HONORABLE_PEOPLE
                    : NICE_RESPECTABLE_ANSWER, person.Name);
            };
        }
    }
}
