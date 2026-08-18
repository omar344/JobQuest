<h1>JobQuest</h1>

<p>JobQuest is a platform that connects freelancers with clients to collaborate on various job opportunities. This repository contains the backend API for JobQuest.</p>

<h2>Features</h2>

<ul>
  <li><strong>Users:</strong> Manage clients and freelancers.</li>
  <li><strong>Jobs:</strong> Create, update, and delete job listings.</li>
  <li><strong>Contracts:</strong> Manage contracts between clients and freelancers.</li>
  <li><strong>Proposals:</strong> Submit proposals for job listings.</li>
  <li><strong>Skills:</strong> Add and remove skills for freelancers.</li>
</ul>

<h2>Technologies Used</h2>

<ul>
  <li><strong>ASP.NET Core:</strong> Backend framework for building the API.</li>
  <li><strong>Entity Framework Core:</strong> Object-relational mapping (ORM) framework for working with databases.</li>
  <li><strong>Swagger:</strong> API documentation tool.</li>
  <li><strong>GitHub Actions:</strong> Continuous integration and deployment (CI/CD) pipeline.</li>
</ul>

<h2>Installation</h2>

<ol>
  <li>Clone the repository:</li>
  <pre><code>git clone https://github.com/your-username/JobQuest.git</code></pre>
  
  <li>Navigate to the project directory:</li>
  <pre><code>cd JobQuest</code></pre>
  
  <li>Install dependencies:</li>
  <pre><code>dotnet restore</code></pre>
  
  <li>Set up the database:</li>
  <ul>
    <li>Update the connection string in <strong>appsettings.json</strong>.</li>
    <li>Run EF migrations:</li>
    <pre><code>dotnet ef database update</code></pre>
  </ul>
  
  <li>Run the application:</li>
  <pre><code>dotnet run</code></pre>
  
  <li>Access the API documentation:</li>
  <p>Navigate to <strong>https://localhost:5001/swagger</strong> in your web browser.</p>
</ol>

<h2>Contributing</h2>

<p>Contributions are welcome! If you have any ideas, enhancements, or bug fixes, please open an issue or create a pull request.</p>
