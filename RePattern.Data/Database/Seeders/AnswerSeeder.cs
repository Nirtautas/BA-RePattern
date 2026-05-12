using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class AnswerSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.Answers.Any())
                return;

            var answers = new List<Answer>
            {
                //Sneak into basket
                new() { Id = 10, Description = "True", IsCorrect = true, TestQuestionId = 10},
                new() { Id = 20, Description = "False", IsCorrect = false, TestQuestionId = 10},

                new() { Id = 30, Description = "True", IsCorrect = false, TestQuestionId = 20},
                new() { Id = 40, Description = "False", IsCorrect = true, TestQuestionId = 20},

                new() { Id = 50, Description = "True", IsCorrect = false, TestQuestionId = 30},
                new() { Id = 60, Description = "False", IsCorrect = true, TestQuestionId = 30},

                new() { Id = 70, Description = "Number 1", IsCorrect = false, TestQuestionId = 40},
                new() { Id = 80, Description = "Number 2", IsCorrect = false, TestQuestionId = 40},
                new() { Id = 90, Description = "Number 3", IsCorrect = false, TestQuestionId = 40},
                new() { Id = 100, Description = "Number 4", IsCorrect = true, TestQuestionId = 40},

                new() { Id = 110, Description = "Yes", IsCorrect = false, TestQuestionId = 50},
                new() { Id = 120, Description = "No", IsCorrect = true, TestQuestionId = 50},

                new() { Id = 130, Description = "Is sneaky in nature.", IsCorrect = true, TestQuestionId = 70},
                new() { Id = 140, Description = "Urges you to buy something.", IsCorrect = false, TestQuestionId = 70},
                new() { Id = 150, Description = "Uses pre-selection.", IsCorrect = true, TestQuestionId = 70},
                new() { Id = 160, Description = "Forces to disclose personal data.", IsCorrect = false, TestQuestionId = 70},

                //Hidden costs
                new() { Id = 170, Description = "True", IsCorrect = true, TestQuestionId = 80},
                new() { Id = 180, Description = "False", IsCorrect = false, TestQuestionId = 80},

                new() { Id = 190, Description = "True", IsCorrect = true, TestQuestionId = 90},
                new() { Id = 200, Description = "False", IsCorrect = false, TestQuestionId = 90},

                new() { Id = 210, Description = "True", IsCorrect = false, TestQuestionId = 100},
                new() { Id = 220, Description = "False", IsCorrect = true, TestQuestionId = 100},

                new() { Id = 230, Description = "True", IsCorrect = false, TestQuestionId = 110},
                new() { Id = 240, Description = "False", IsCorrect = true, TestQuestionId = 110},

                new() { Id = 250, Description = "Exploits user\'s effort.", IsCorrect = true, TestQuestionId = 130},
                new() { Id = 260, Description = "Sneaks in unwanted products or services.", IsCorrect = false, TestQuestionId = 130},
                new() { Id = 270, Description = "Manifests at the end of the checkout process.", IsCorrect = true, TestQuestionId = 130},
                new() { Id = 280, Description = "Inflates the final order price.", IsCorrect = true, TestQuestionId = 130},

                new() { Id = 290, Description = "Number 1", IsCorrect = false, TestQuestionId = 140},
                new() { Id = 300, Description = "Number 2", IsCorrect = false, TestQuestionId = 140},
                new() { Id = 310, Description = "Number 3", IsCorrect = true, TestQuestionId = 140},
                new() { Id = 320, Description = "Number 4", IsCorrect = false, TestQuestionId = 140},

                //Hidden subscription
                new() { Id = 330, Description = "True", IsCorrect = true, TestQuestionId = 150},
                new() { Id = 340, Description = "False", IsCorrect = false, TestQuestionId = 150},

                new() { Id = 350, Description = "True", IsCorrect = true, TestQuestionId = 160},
                new() { Id = 360, Description = "False", IsCorrect = false, TestQuestionId = 160},

                new() { Id = 370, Description = "True", IsCorrect = false, TestQuestionId = 170},
                new() { Id = 380, Description = "False", IsCorrect = true, TestQuestionId = 170},

                new() { Id = 390, Description = "May automatically add or renew a subscription without consent.", IsCorrect = true, TestQuestionId = 190},
                new() { Id = 400, Description = "Uses confusing and technical language.", IsCorrect = false, TestQuestionId = 190},
                new() { Id = 410, Description = "Uses fake activity messages", IsCorrect = false, TestQuestionId = 190},
                new() { Id = 420, Description = "May not send reminders about a recurring subscription.", IsCorrect = true, TestQuestionId = 190},

                new() { Id = 430, Description = "Number 1", IsCorrect = false, TestQuestionId = 200},
                new() { Id = 440, Description = "Number 2", IsCorrect = false, TestQuestionId = 200},
                new() { Id = 450, Description = "Number 3", IsCorrect = false, TestQuestionId = 200},
                new() { Id = 460, Description = "Neither", IsCorrect = true, TestQuestionId = 200},

                //Limited time message
                new() { Id = 470, Description = "True", IsCorrect = true, TestQuestionId = 210},
                new() { Id = 480, Description = "False", IsCorrect = false, TestQuestionId = 210},

                new() { Id = 490, Description = "True", IsCorrect = true, TestQuestionId = 220},
                new() { Id = 500, Description = "False", IsCorrect = false, TestQuestionId = 220},

                new() { Id = 510, Description = "True", IsCorrect = false, TestQuestionId = 230},
                new() { Id = 520, Description = "False", IsCorrect = true, TestQuestionId = 230},

                new() { Id = 530, Description = "Elicits a negative emotional response, such as \"shame\" or \"guilt\".", IsCorrect = false, TestQuestionId = 250},
                new() { Id = 540, Description = "Urges users.", IsCorrect = true, TestQuestionId = 250},
                new() { Id = 550, Description = "Does not disclose the exact offer deadline.", IsCorrect = true, TestQuestionId = 250},
                new() { Id = 560, Description = "Makes certain situations hard to exit from.", IsCorrect = false, TestQuestionId = 250},

                new() { Id = 570, Description = "Number 1", IsCorrect = true, TestQuestionId = 260},
                new() { Id = 580, Description = "Number 2", IsCorrect = false, TestQuestionId = 260},
                new() { Id = 590, Description = "Number 3", IsCorrect = false, TestQuestionId = 260},
                new() { Id = 600, Description = "Number 4", IsCorrect = false, TestQuestionId = 260},

                //Confirmshaming
                new() { Id = 610, Description = "True", IsCorrect = true, TestQuestionId = 270},
                new() { Id = 620, Description = "False", IsCorrect = false, TestQuestionId = 270},

                new() { Id = 630, Description = "True", IsCorrect = true, TestQuestionId = 280},
                new() { Id = 640, Description = "False", IsCorrect = false, TestQuestionId = 280},

                new() { Id = 650, Description = "True", IsCorrect = false, TestQuestionId = 290},
                new() { Id = 660, Description = "False", IsCorrect = true, TestQuestionId = 290},

                new() { Id = 670, Description = "Elicits a negative emotional response, such as \"shame\" or \"guilt\".", IsCorrect = true, TestQuestionId = 310},
                new() { Id = 680, Description = "Uses self-destructive or condescending wording.", IsCorrect = true, TestQuestionId = 310},
                new() { Id = 690, Description = "Uses \"double negatives\" or \"inversion of choices\".", IsCorrect = false, TestQuestionId = 310},
                new() { Id = 700, Description = "Only reveals itself at the end of the checkout process.", IsCorrect = false, TestQuestionId = 310},

                new() { Id = 710, Description = "Number 1", IsCorrect = false, TestQuestionId = 320},
                new() { Id = 720, Description = "Number 2", IsCorrect = false, TestQuestionId = 320},
                new() { Id = 730, Description = "Number 3", IsCorrect = false, TestQuestionId = 320},
                new() { Id = 740, Description = "Number 4", IsCorrect = true, TestQuestionId = 320},

                //Visual interference
                new() { Id = 750, Description = "True", IsCorrect = true, TestQuestionId = 330},
                new() { Id = 760, Description = "False", IsCorrect = false, TestQuestionId = 330},

                new() { Id = 770, Description = "True", IsCorrect = true, TestQuestionId = 340},
                new() { Id = 780, Description = "False", IsCorrect = false, TestQuestionId = 340},

                new() { Id = 790, Description = "True", IsCorrect = true, TestQuestionId = 350},
                new() { Id = 800, Description = "False", IsCorrect = false, TestQuestionId = 350},

                new() { Id = 801, Description = "Uses presentation and style to manipulate.", IsCorrect = true, TestQuestionId = 370},
                new() { Id = 810, Description = "May place information in unexpected places.", IsCorrect = true, TestQuestionId = 370},
                new() { Id = 820, Description = "May use small text with low contrast.", IsCorrect = true, TestQuestionId = 370},
                new() { Id = 830, Description = "Uses \"double negatives\" or \"inversion of choices\".", IsCorrect = false, TestQuestionId = 370},

                new() { Id = 840, Description = "Number 1", IsCorrect = true, TestQuestionId = 380},
                new() { Id = 850, Description = "Number 2", IsCorrect = false, TestQuestionId = 380},
                new() { Id = 860, Description = "Number 3", IsCorrect = false, TestQuestionId = 380},
                new() { Id = 870, Description = "Neither", IsCorrect = false, TestQuestionId = 380},

                //Trick questions
                new() { Id = 880, Description = "True", IsCorrect = true, TestQuestionId = 390},
                new() { Id = 890, Description = "False", IsCorrect = false, TestQuestionId = 390},

                new() { Id = 900, Description = "True", IsCorrect = true, TestQuestionId = 400},
                new() { Id = 910, Description = "False", IsCorrect = false, TestQuestionId = 400},

                new() { Id = 920, Description = "True", IsCorrect = false, TestQuestionId = 410},
                new() { Id = 930, Description = "False", IsCorrect = true, TestQuestionId = 410},

                new() { Id = 940, Description = "Uses presentation and style to manipulate.", IsCorrect = false, TestQuestionId = 430},
                new() { Id = 950, Description = "Uses self-destructive or condescending wording.", IsCorrect = false, TestQuestionId = 430},
                new() { Id = 960, Description = "Uses \"double negatives\" or \"inversion of choices\".", IsCorrect = true, TestQuestionId = 430},
                new() { Id = 970, Description = "Manipulates consumers through their expectations.", IsCorrect = true, TestQuestionId = 430},

                new() { Id = 980, Description = "Number 1", IsCorrect = false, TestQuestionId = 440},
                new() { Id = 990, Description = "Number 2", IsCorrect = true, TestQuestionId = 440},
                new() { Id = 1000, Description = "Number 3", IsCorrect = false, TestQuestionId = 440},
                new() { Id = 1010, Description = "Neither", IsCorrect = false, TestQuestionId = 440},

                //Hard to cancel
                new() { Id = 1020, Description = "True", IsCorrect = true, TestQuestionId = 450},
                new() { Id = 1030, Description = "False", IsCorrect = false, TestQuestionId = 450},

                new() { Id = 1040, Description = "True", IsCorrect = true, TestQuestionId = 460},
                new() { Id = 1050, Description = "False", IsCorrect = false, TestQuestionId = 460},

                new() { Id = 1060, Description = "True", IsCorrect = false, TestQuestionId = 470},
                new() { Id = 1070, Description = "False", IsCorrect = true, TestQuestionId = 470},

                new() { Id = 1080, Description = "Makes it hard for users to cancel their services or subscriptions.", IsCorrect = true, TestQuestionId = 490},
                new() { Id = 1090, Description = "Urges users.", IsCorrect = false, TestQuestionId = 490},
                new() { Id = 1100, Description = "Forces to disclose personal data.", IsCorrect = false, TestQuestionId = 490},
                new() { Id = 1110, Description = "Sneaks in unwanted products or services.", IsCorrect = false, TestQuestionId = 490},

                new() { Id = 1120, Description = "Number 1", IsCorrect = true, TestQuestionId = 500},
                new() { Id = 1130, Description = "Number 2", IsCorrect = false, TestQuestionId = 500},
                new() { Id = 1140, Description = "Number 3", IsCorrect = false, TestQuestionId = 500},
                new() { Id = 1150, Description = "Number 4", IsCorrect = false, TestQuestionId = 500},

                //Forced enrollment
                new() { Id = 1160, Description = "True", IsCorrect = true, TestQuestionId = 510},
                new() { Id = 1170, Description = "False", IsCorrect = false, TestQuestionId = 510},

                new() { Id = 1180, Description = "True", IsCorrect = true, TestQuestionId = 520},
                new() { Id = 1190, Description = "False", IsCorrect = false, TestQuestionId = 520},

                new() { Id = 1200, Description = "True", IsCorrect = false, TestQuestionId = 530},
                new() { Id = 1210, Description = "False", IsCorrect = true, TestQuestionId = 530},

                new() { Id = 1220, Description = "Makes it hard for users to cancel their services or subscriptions.", IsCorrect = false, TestQuestionId = 550},
                new() { Id = 1230, Description = "Coerces users to perform additional unwanted or unrelated tasks", IsCorrect = true, TestQuestionId = 550},
                new() { Id = 1240, Description = "May force to disclose personal data.", IsCorrect = true, TestQuestionId = 550},
                new() { Id = 1250, Description = "Uses presentation and style to manipulate.", IsCorrect = false, TestQuestionId = 550},

                new() { Id = 1260, Description = "Number 1", IsCorrect = true, TestQuestionId = 560},
                new() { Id = 1270, Description = "Number 2", IsCorrect = false, TestQuestionId = 560},
                new() { Id = 1280, Description = "Number 3", IsCorrect = false, TestQuestionId = 560},
                new() { Id = 1290, Description = "Number 4", IsCorrect = false, TestQuestionId = 560},
            };

            SeederSqlServerHelper.SeedWithIdentityInsert(context, "Answer", context.Answers, answers);
        }
    }
}
