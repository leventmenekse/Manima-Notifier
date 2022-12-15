<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">

<h3 align="center">Manima Notifier</h3>

  <p align="center">
    The aim of the project is to gather systems such as mail and sms under one roof and to ensure that they are managed from a single point. 
    <br />
    It currently supports SendInBlue and SendGrid mail providers. More will be coming soon...
    <br />
    <br />
    <a href="https://github.com/leventmenekse/Manima-Notifier/issues">Report Bug</a>
    ·
    <a href="https://github.com/leventmenekse/Manima-Notifier/issues">Request Feature</a>
  </p>
</div>

### Built With

* [![.Net][.Net]][Net-url]
* [![MongoDb][MongoDb]][MongoDb-url]
* [![RabbitMq][RabbitMq]][RabbitMq-url]
* [![VisualStudio][VisualStudio]][VisualStudio-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

You need to have .net core 6, mongodb and rabbtimq and docker in order to execute the project. 

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/leventmenekse/Manima-Notifier.git
   ```
2. Restore packages
3. Set ManimaTech.Notification.Sender as default project
4. You should see docker-compose.yml file under ManimaTech.Notification.Sender project. Place it any where on your computer and run.
   ```sh
   docker-compose up
   ```
5. Fill appsettings.json as you need
7. Run

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- USAGE EXAMPLES -->
## Usage

In order to send notification to your users, you need to publish your messages to rabbitmq's exchange. Listener accepts mongo id only. It checks if the message in database.
If it is in the database then sending process begins. 

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTRIBUTING -->
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



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Levent Menekse - menekselevent@gmail.com

Project Link: [https://github.com/leventmenekse/Manima-Notifier](https://github.com/leventmenekse/Manima-Notifier)

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/leventmenekse)

<br />
<p align="right">(<a href="#readme-top">back to top</a>)</p>




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/leventmenekse/Manima-Notifier.svg?style=for-the-badge
[contributors-url]: https://github.com/leventmenekse/Manima-Notifier/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/leventmenekse/Manima-Notifier.svg?style=for-the-badge
[forks-url]: https://github.com/leventmenekse/Manima-Notifier/network/members
[stars-shield]: https://img.shields.io/github/stars/leventmenekse/Manima-Notifier.svg?style=for-the-badge
[stars-url]: https://github.com/leventmenekse/Manima-Notifier/stargazers
[issues-shield]: https://img.shields.io/github/issues/leventmenekse/Manima-Notifier.svg?style=for-the-badge
[issues-url]: https://github.com/leventmenekse/Manima-Notifier/issues
[license-shield]: https://img.shields.io/github/license/leventmenekse/Manima-Notifier.svg?style=for-the-badge
[license-url]: https://github.com/leventmenekse/Manima-Notifier/blob/main/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/leventmenekse
[product-screenshot]: images/screenshot.png
[.Net]: https://img.shields.io/badge/.Net-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[Net-url]: https://dotnet.microsoft.com/en-us/download
[MongoDb]: https://img.shields.io/badge/MongoDB-47A248?style=for-the-badge&logo=mongodb&logoColor=white
[MongoDb-url]: https://www.mongodb.com/home
[RabbitMq]: https://img.shields.io/badge/RabbitMQ-FF6600?style=for-the-badge&logo=rabbitmq&logoColor=white
[RabbitMq-url]: https://www.rabbitmq.com/
[VisualStudio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white
[VisualStudio-url]: https://visualstudio.microsoft.com/
