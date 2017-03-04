# Wingo's Web Portfolio

This project was generated with Visual Studio 2015 Community

## Prerequisites

You will need the following things properly installed on your computer.

* [Visual Studio](https://www.visualstudio.com/downloads/)

## Installation

* `git clone <https://github.com/Cmwingo/.Net-WingoWeb>` this repository

## Github API Instructions

* You will need to create a file in the `.Net-WingoWeb\src\.Net-WingoWeb\Models` folder called `EnvironmentVariables.cs`
* Open the file and add the follwing code 
``` using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	namespace WingoWeb
	{
		public class EnvironmentVariables
		{
			public static string userName = "<YOUR GITHUB USERNAME>";
			public static string password = "<YOUR GITHUB PASSWORD";
		}
	}
```
* Note: This will show your starred repositories on the project page *NOT* mine. Just so you can see the API works.
* You should then be able to run the project in Visual Studio

## Inspired By
This site's design was inspired by https://www.oldtimecandy.com/

## Known Bugs

_No known issues at this time_

## Support and contact details

_Please feel free to contact me with questions, comments, or contributions to improve the program at cmwingo@gmail.com_

### License

*https://creativecommons.org/licenses/by-nc/3.0/us/legalcode*

Copyright (c) 2017 **_Chris Wingo_**