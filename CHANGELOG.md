# Change Log

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/) and this project adheres to [Semantic Versioning](https://semver.org/).

## [1.2.2] - 2022-02-27
### Changed
* Renamed incorrect `RemoveRobots` extension method

## [1.2.1] - 2021-06-29
### Changed
* Default `IRobotsBuilder` implementations are public to improve extensibility
* Default configuration is registered once per application lifecycle
* `IRobotsBuilder` is initialised only when requested and within an `UmbracoContext`

## [1.2.0] - 2021-06-24
### Added
* Custom `IRobotsBuilder`s and routes are registerable at startup

### Changed
* `IRobotsBuilder` takes a culture for multi-lingual content
* Files are cached for 15 minutes
* Default configuration is more easily extensible

## [1.1.0] - 2020-08-17
### Added
* Default output can now be overwritten with `IRobotsBuilder` 
* Documentation for configuring Friendly Robots

### Changed
* Combined `RobotsConfigComposer` and `RobotsRouteComposer` into `RobotsComposer`

### Fixed
* Improved handling of null config values

## [1.0.0] - 2019-10-27
### Added
* Initial release of Friendly Robots for Umbraco 8.1

[Unreleased]: https://github.com/callumbwhyte/friendly-robots/compare/release-1.2.2...HEAD
[1.2.2]: https://github.com/callumbwhyte/friendly-robots/compare/release-1.2.1...release-1.2.2
[1.2.1]: https://github.com/callumbwhyte/friendly-robots/compare/release-1.2.0...release-1.2.1
[1.2.0]: https://github.com/callumbwhyte/friendly-robots/compare/release-1.1.0...release-1.2.0
[1.1.0]: https://github.com/callumbwhyte/friendly-robots/compare/release-1.0.0...release-1.1.0
[1.0.0]: https://github.com/callumbwhyte/friendly-robots/tree/release-1.0.0