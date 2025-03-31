<a name="readme-top"></a>

<br />
<div align="center">
<h3 align="center">My Blog Site API</h3>

  <p align="center">
     C#, Entity Framework Core, ASP.NET, SQL REST API to be used with My Blog Site UI
    <br />
<!--     <a href="https://blogsite-8fced.web.app/" target="_blank">View Demo</a> -->
    ·
    <a href="https://github.com/Amiriel01/BlogSiteUI/issues" target="_blank">Report Bug</a>
    ·
    <a href="https://github.com/Amiriel01/BlogSiteUI/issues" target="_blank">Suggestions</a>
  </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#features">Features</a></li>
      </ul>
      <ul>
        <li><a href="#api-endpoints">API Endpoints</a></li>
      </ul>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

## About The Project

Welcome to the README for the My Blog Site API! This API is built using C#, ASP.Net Core Web API, Entity Framework Core, JWT, and interacts with a SQL database. It serves as the REST API for My Blog Site UI, providing endpoints for managing blog posts, comments, users, and other related functionalities.

If you notice any bugs or have an idea to make this API even better please use the links above to make your suggestions! Thank you!

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Features

* Blog Posts: Create, read, update, and delete blog posts.
* Categories: Create, read, update, and delete categories.
* Users: Authentication and authorization are implemented to manage users.
* Image Upload: Create and read image uploads.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### API Endpoints

GET Endpoints do not require authorization or authentication. All others require an admin authenticated user with the role Writer.

***Authentication Endpoints***

* POST: /api/auth/login
* POST: /api/auth/register

***Blog Post Endpoints***

* POST: /api/blogposts
* GET: /api/blogposts
* GET: /api/blogposts/{id}
* GET: /api/blogPosts/{urlhandle}
* PUT: /api/blogposts/{id}
* DELETE: /api/blogposts/{id}

***Category Endpoints***

* GET: /api/Catagories
* PUT: /api/Catagories/{id}
* DELETE: /api/Catagories/{id}
* POST: /api/Catagories/{id}

***Image Upload Endpoints***
* GET: /api/Images
* POST: /api/Images

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

* [![C#][C#.io]][C#-url]
* [![JWT][JWT.io]][JWT-url]
* [![NET][NET.io]][NET-url]
* [![SQL][SQL.io]][SQL-url]
* [![VS][VS.io]][VS-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Getting Started

To get a local copy up and running follow these simple example steps.

### Installation

1. Clone the Repository: Clone this repository to your local machine.
   ```sh
   git clone https://github.com/Amiriel01/MyBlogSiteAPI
   ```
2. Database Setup: Configure your SQL database connection string in the appsettings.json file.
   ```sh
   "ConnectionStrings": {
   "DefaultConnection": "Server=your-server;Database=blogdb;User=your-username;Password=your-password;"
   }
   ```
3. Run Migrations: Apply Entity Framework migrations to create the necessary tables in the database.
   ```sh
    dotnet ef database update
   ```
4. Run the Application: Start the API application.
   ```sh
    dotnet run
   ```
   
<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Acknowledgments

* [Pexels: Website Images](https://www.pexels.com/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

[C#.io]: https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white
[C#-url]: https://learn.microsoft.com/en-us/dotnet/csharp/
[NET.io]: https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white
[NET-url]: https://learn.microsoft.com/en-us/dotnet/
[JWT.io]: https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens
[JWT-url]: https://jwt.io/introduction
[SQL.io]: https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white
[SQL-url]: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
[VS.io]: https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white
[VS-url]: https://visualstudio.microsoft.com/
