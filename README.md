# Umbraco Friendly Robots

<img src="docs/img/logo.png?raw=true" alt="Umbraco Friendly Robots" width="250" align="right" />

[![NuGet](https://img.shields.io/nuget/v/Our.Umbraco.FriendlyRobots.svg)](https://www.nuget.org/packages/Our.Umbraco.FriendlyRobots/)
[![Our Umbraco](https://img.shields.io/badge/our-umbraco-orange.svg)](https://our.umbraco.com/projects/website-utilities/friendly-robots/)

Friendly Robots makes adding a dynamic robots.txt file to your Umbraco website easy!

## Getting started

Friendly Robots is supported on Umbraco 8.1+.

### Installation

Friendly Robots is available from Our Umbraco, NuGet, or as a manual download directly from GitHub.

#### Our Umbraco repository

You can find a downloadable package, along with a discussion forum for this package, on the [Our Umbraco](https://our.umbraco.com/projects/website-utilities/friendly-robots/) site.

#### NuGet package repository

To [install from NuGet](https://www.nuget.org/packages/Our.Umbraco.FriendlyRobots/), run the following command in your instance of Visual Studio.

    PM> Install-Package Our.Umbraco.FriendlyRobots

## Usage

Once installed, the robots.txt file will be visible on the URL `/robots.txt`, such as `https://www.yoursite.com/robots.txt`.

If a physical `robots.txt` file exists in the root of the website, the dynamically generated file will be overwritten.

### Configuration

By default the robots.txt is automatically set to **allow all** traffic, but can be configured via a selection of app settings in the `web.config`.

Unless an alternative value is supplied, the "useragent" field will be *catch-all* ("*").

```
<add key="Umbraco.Robots.UserAgent" value="*" />
```

Multiple values can be supplied for each of the "allow", "disallow", and "sitemaps" URL fields as a comma separated list, like this:

```
<add key="Umbraco.Robots.Disallow" value="/some-path/,/some-other-path/" />
```

The [project wiki](https://github.com/callumbwhyte/friendly-robots/wiki) contains further details about the advanced configuration options available.

## Contribution guidelines

To raise a new bug, create an issue on the GitHub repository. To fix a bug or add new features, fork the repository and send a pull request with your changes. Feel free to add ideas to the repository's issues list if you would to discuss anything related to the library.

### Who do I talk to?

This project is maintained by [Callum Whyte](https://callumwhyte.com/) and contributors. If you have any questions about the project please get in touch on [Twitter](https://twitter.com/callumbwhyte), or by raising an issue on GitHub.

## Credits

The logo uses the [Robot](https://thenounproject.com/term/robot/2490617/) icon from the [Noun Project](https://thenounproject.com) by [Adrien Coquet](https://thenounproject.com/coquet_adrien/), licensed under [CC BY 3.0 US](https://creativecommons.org/licenses/by/3.0/us/).

## License

Copyright &copy; 2021 [Callum Whyte](https://callumwhyte.com/), and other contributors

Licensed under the [MIT License](LICENSE.md).