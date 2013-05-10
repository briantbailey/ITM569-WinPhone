#ITM569 Windows Phone API Project
- - - 

**Vesion: 1.0**

The intention of this project is to build a Windows Phone 7 
application that uses a public API to consume and display data. 
This application uses the City of Chicago's data API which is 
provided by Socrata and uses their soda format.

I used the data resource from the City of Chicago that lists 
crimes reported in the last calendar year, excluding murder. 
The City data is located at the following link.

[Chicago One Year Crime Database](https://data.cityofchicago.org/Public-Safety/Crimes-One-year-prior-to-present/x2n5-8w5q)

The application allows you to search the database based on your 
current GPS coordinates. It gives you the options to limit the date 
range and distance from the location. You also have the option 
to input an address to search based on that address. Once 
you get the list or crimes that fit your search parameters, you 
can select one and it will show you all the details in that report.

##Features

+ Search for local Chicago Crime Reports based on location
+ Choose distance radius to search within
+ Choose from various amounts of time to search
+ Geolocate an address and search from that address as your location
+ The full details of the record in the database can be viewed  
    
##Windows Phone Support

The application is targeted to the Windows Phone 7.8 sdk. The application
was only tested in the emulator and not on an actual device. 

####GPS Testing:####

In the Windows Phone emulator you can enter GPS coordinates to send to the 
device. I found this to be very reliable and worked as expected. The 
option can be found in the pop up menu items to the right of the emulator. 
Select the arrows and in the window that pops up go to the location tab. 
A map will appear and let you click to select a coordinate. The last 
coordinate pin you set down will be the one used. 

The application limits the search to GPS coordinates in the City of 
Chicago. If you are going to input your own coordinates please choose 
ones that are located in the city. 

If you would like to use the fixed coordinates I used during most 
of my testing they are provided here. These are the coordinates of the 
IIT Tower.

+ Latitude: 41.83128
+ Longitude: -87.62697

##Version History

1.0 -- May 9, 2013 -- Version turned in to Professor

##Sources

[Chicago One Year Crime Database](https://data.cityofchicago.org/Public-Safety/Crimes-One-year-prior-to-present/x2n5-8w5q)

[Socrata Soda API](http://dev.socrata.com/)