# WeatherAggregator

### Short summary
This project is done for private purposes like grabbing weather from open api resources. 
This project is REST, so it uses all .Net features that help us to create such websites.

The back-end side of WeatherAggregator is written on C# 5.0 and the front-end is written on BackboneTs (BackboneJs + typescript).


### How to deploy
First of all, if you do not have the IIS server, [install it](http://www.howtogeek.com/112455/how-to-install-iis-8-on-windows-8/) to deploy your changes locally.

1. Create two application pools for running the application. You can name them like [WeatherApi and WeatherWebsite](https://i.imgur.com/0eUl2Nt.png)
2. Open advanced settings and change the application identity to [local system](https://i.imgur.com/dd7armm.png)
3. Create two websites like [this](https://i.imgur.com/Hnh4uPa.png)
4. My application requires ssl certificates. How to add website with https you can find [there](https://www.digicert.com/ssl-certificate-installation-microsoft-iis-7.htm)
5. To build my application you need at least VS2013 with [Typescript extension](https://www.microsoft.com/en-us/download/details.aspx?id=48593).
6. Please find out that Typescript might not be built. In this case you should install a suitable version of TS compiler.
7. Add the path to your back-end application at the URLConstants.ts.
8. Build it.
9. If all is done and you do not have errors you are able to see the result at https://yourip:port

### How to add new weather service

1. Find some service that provides any kind of weather api, it should return country name, city name and temperature in Celcius as json.
2. Convert your found api into C# types by [json converter](http://json2csharp.com/)
3. Add them to the models project.
4. Convert all inconsistent weather api fields by mapper into WeatherConvention model to use them later.
5. Add new weather repository and instantiate it with your new weather api type.
6. Add new metadata to be sure that your new weather api grabs data successfully.
7. Resolve all occured errors by reading the output from debug. Probably you have forgotten to add your api name to WeatherNamesRepository or to resolve them in autofac.
8. Enjoy :)

