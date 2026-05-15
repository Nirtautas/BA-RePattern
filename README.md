## General information

This is "RePattern" - an open-source educational application for e-commerce deceptive pattern identification. It was developed by Nirtautas Šadauskas - a 4th year Vilnius University Software Engineering program student, aiming to attain a Bachelor's degree. The primary goal of this application is to interactively educate consumers about various deceptive patterns often found in e-commerce websites and about the means of their manipulation. The current version contains learning material for 9 deceptive patterns, with plans to add more of it in the future.

Folders titled "RePattern", contain the backend .NET, while the "client" folder contains the Next.ts frontend.

The application is deployed [HERE](https://ba-re-pattern.vercel.app/). If you wish to deploy this application locally, you will need to add the following environment variables:

1. Frontend
   - NEXT_PUBLIC_BACKEND_BASE_URL - URL of the deployed backend API.
   - NEXT_PUBLIC_INTERACTIVE_WEBSITE_URL - URL of the deployed interactive exercise module. ([See repository](https://github.com/Nirtautas/BA-Usability-study-website-educational-website-fork))
2. Backend
   - FrontEndBaseUrl - URL of the deployed Next.ts frontend.
   - REPATTERN_DATABASE_URL - SQLServer database connection string.
   - RePatternJwtKey - Generated JWT private key.
   - RePatternIssuer - JWT issuer.
   - RePatternAudience - JWT audience.
   - GmailOptions__Host - Gmail SMTP host server.
   - GmailOptions__Port - Gmail SMTP host server port.
   - GmailOptions__Name - Name of the sender.
   - GmailOptions__Email - Email of the sender.
   - GmailOptions__Password - Password of the sender. (App password)
