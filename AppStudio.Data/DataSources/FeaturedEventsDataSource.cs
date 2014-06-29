using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class FeaturedEventsDataSource : IDataSource<FeaturedEventsSchema>
    {
        private readonly IEnumerable<FeaturedEventsSchema> _data = new FeaturedEventsSchema[]
        {
            new FeaturedEventsSchema() {
                Event_Name="Independence Eve Presented by Anadarko",
                Event_Date="July 3, 8 p.m.",
                Event_Location="Civic Center Park, Broadway and Colfax",
                Event_Cost="Free",
                Link_1="http://www.denver.org/includes/calendar-of-events/Independence-Eve/20461/",
                Link_2="http://www.denver.org/listings/Civic-Center-Park/6823/",
                Event_Description="The annual Independence Eve Celebration in Civic Center Park will feature a free patriotic concert, an innovative light show on the Denver City and County Building and a stunning fireworks finale. The concert will feature patriotic and pop favorites from MIX, CU Denver's award-winning a capella group; the Hazel Miller Band and the Denver Municipal Band. Lawn seating will be available on a first-come, first-served basis; blankets or low-rise concert/beach chairs are encouraged. Attendees are welcome to bring their own picnics; concessions will also be present on-site. Civic Center is easily accessible by light rail, bus, bicycle or the 16th Street FREE MallRide and use of public transportation is encouraged. Information on nearby Denver B-cycle bike-sharing locations is available. Parking is available at nearby surface lots and parking garages as well.",
                Event_Image="http://www.denver.org/includes/content/images/media/CIVIC-CENTER-Fireworks.jpg",
                Latitude=39.739236, 
                Longitude=-104.990098
            },
            new FeaturedEventsSchema() {
                Event_Name="Independence Day Strikes Back Featuring the Colorado Symphony",
                Event_Date="July 4 (doors open: 6:30 p.m., showtime: 7:30 p.m.",
                Event_Location="Fiddler's Green Amphitheatre, 6350 Greenwood Plaza Blvd., Greenwood Village",
                Event_Cost= "$17-$35",
                Link_1="http://www.denver.org/includes/calendar-of-events/Independence-Day-Strikes-Back-feat-The-Colorado-Symphony/21269/",
                Link_2="",
                Event_Description="Celebrate Independence Day with your Colorado Symphony and a fantastic fireworks show! Enjoy this unique tribute to the good ol' USA and favorites from Star Wars and more. The concert will also feature patriotic favorites including the \"Armed Forces Salute\" and \"Stars and Stripes Forever.\"",
                Event_Image="http://www.denver.org/includes/content/images/media/independence-day-strikes-back-feat-the-colorado-symphony-tickets_07-05-14_3_537669c761fa2.jpg",
                Latitude=39.601337,
                Longitude=-104.8928318
            },
            new FeaturedEventsSchema() {
                Event_Name="Cherry Creek Arts Festival",
                Event_Date="July 4-6",
                Event_Location="Cherry Creek North, from 2nd to 3rd Avenues, on the seven streets between Columbine and Steele Sts.",
                Event_Cost="Free",
                Link_1="http://www.denver.org/includes/calendar-of-events/Cherry-Creek-Arts-Festival/1948/",
                Link_2="",
                Event_Description="This free, outdoor extravaganza - the city's signature cultural celebration of the visual, performing and culinary arts - gives more than 350,0000 annual visitors the chance to meet and talk with international visual artists, enjoy a wide range of family friendly fun sample fine cuisine. At the Cherry Creek Arts Festival , experience Artivity Avenue, a full block of interactive activities perfect for youngsters. Visit the Cultural Pavilion, where music, dance and theater from around the globe will be presented. Culinary Avenue features tasty treats and live cooking demonstrations from some of Denver's most popular eateries.",
                Event_Image="http://www.denver.org/includes/content/images/media/1492013-705-113047.jpg",
                Latitude=39.720052, 
                Longitude=-104.953434
            },
            new FeaturedEventsSchema() {
                Event_Name="Concerts at Red Rocks",
                Event_Date="July 4-5",
                Event_Location="Red Rocks Amphitheatre and State Park, 18300 W. Alameda Pkwy., Morrison",
                Event_Cost="Varies",
                Link_1="http://www.denver.org/listings/Red-Rocks-Amphitheatre-Visitors-Center/4574/",
                Link_2="",
                Event_Description="Celebrate Independence Day Weekend at Red Rocks ! July 4 brings jam band favorites Blues Traveler back to the Rocks, and they've stacked the lineup with Sugar Ray, Smash Mouth and Uncle Kracker. July 5 sees the improvisatory genius of Umphrey's McGee arrive at this one-of-a-kind venue.",
                Event_Image="http://www.denver.org/includes/content/images/media/BLues-Traveler.jpg",
                Latitude=39.665534, 
                Longitude=-105.205534
            },
            new FeaturedEventsSchema() {
                Event_Name="Frozen in Skyline Park",
                Event_Date="July 5",
                Event_Location="Skyline Park, at the corner of Arapahoe and 16th",
                Event_Cost="Free",
                Link_1="http://www.denver.org/includes/calendar-of-events/Skyline-Park-Movies---Frozen/21206/",
                Link_2="",
                Event_Description="Don't miss your chance to see the latest Disney animated blockbuster for FREE, under the stars in the heart of downtown Denver. Frozen tells the story of Princesses Anna and Elsa and their adventures in the icy kingdom of Arendelle.",
                Event_Image="http://www.denver.org/includes/content/images/media/skyline-movie.jpg",
                Latitude=39.748313, 
                Longitude=-104.995434
            },
            new FeaturedEventsSchema() {
                Event_Name="Fireworks at Elitch Gardens Theme & Water Park",
                Event_Date="July 4",
                Event_Location="Elitch Gardens Theme & Water Park, 2000 Elitch Cir.",
                Event_Cost="Tickets start at $34.99",
                Link_1="http://www.denver.org/listings/Elitch-Gardens-Theme-Water-Park/3638/",
                Link_2="",
                Event_Description="Spend the day riding the roller coasters and the water slides at Elitch Gardens Theme & Water Park , Denver's downtown amusement park, and then watch a brilliant fireworks display light up the night sky, starting at dusk.",
                Event_Image="http://svcdn.simpleviewinc.com/v3/cache/www_denver_org/91DC7C8AE79474A81D943ED583B8CCFB.jpg",
                Latitude=39.750906, 
                Longitude=-105.010599
            },
            new FeaturedEventsSchema() {
                Event_Name="Park Hill 4th of July Parade",
                Event_Date="July 4",
                Event_Location="Park Hill, on 23rd Ave. from Dexter St. to Krameria St.",
                Event_Cost="Free",
                Link_1="http://www.denver.org/includes/calendar-of-events/Park-Hill-4th-of-July-Parade/20120/",
                Link_2="",
                Event_Description="The Park Hill 4th of July Parade is back! This community-friendly event will again be marching along 23rd Avenue on Independence Day. This year's parade promises to be bigger than ever before, with marching bands, acrobats and festive floats.",
                Event_Image="http://www.denver.org/includes/content/images/media/Park-Hill-Parade.jpg",
                Latitude=39.751099, 
                Longitude=-104.928167
            },
            new FeaturedEventsSchema() {
                Event_Name="The Rockies - and FIREWORKS!",
                Event_Date="July 3-6",
                Event_Location="Coors Field, 2001 Blake St.",
                Event_Cost="Rockpile tickets start at $4",
                Link_1="http://www.denver.org/includes/calendar-of-events/Colorado-Rockies-vs-Los-Angeles-Dodgers/17464/",
                Link_2="",
                Event_Description="Catch The Colorado Rockies taking on the Los Angeles Dodgers during a four-game homestand. There will be a spectacular fireworks show following the July 3 and 4 games!",
                Event_Image="http://www.denver.org/includes/content/images/media/2872013-709-141549-0.jpg",
                Latitude=39.756305, 
                Longitude=-104.994178
            },
            new FeaturedEventsSchema() {
                Event_Name="The Rapids - and FIREWORKS!",
                Event_Date="July 4",
                Event_Location="Dick's Sporting Goods Park, 6000 Victory Way, Commerce City",
                Event_Cost="Tickets start at $29",
                Link_1="http://www.denver.org/includes/calendar-of-events/Colorado-Rapids-vs-Columbus-Crew/18416/",
                Link_2="",
                Event_Description="Denver's hometown heroes the Colorado Rapids are taking on the Columbus Crew on July 4 - stick around for the fireworks display after the game!",
                Event_Image="http://www.denver.org/includes/content/images/media/3432013-289-135716-0.jpg",
                Latitude=39.805432, 
                Longitude=-104.891860
            },
            new FeaturedEventsSchema() {
                Event_Name="The Outlaws - and FIREWORKS!",
                Event_Date="July 4",
                Event_Location="Sports Authority Field at Mile High, 1701 Bryant St.",
                Event_Cost="Tickets start at $26",
                Link_1="http://www.denver.org/includes/calendar-of-events/Denver-Outlaws-vs-Boston-Cannons/19143/",
                Link_2="http://www.denver.org/listings/Sports-Authority-Field-at-Mile-High/4559/",
                Event_Description="Denver's professional lacrosse team the Denver Outlaws are battling it out with the Boston Cannons . After the game, enjoy fireworks within the bowl at Sports Authority Field at Mile High - pyrotechnics paired with visuals on a 220-foot wide, hi-definition screen. You'll never forget this kind of fireworks show!",
                Event_Image="http://www.denver.org/includes/content/images/media/232014-705-13855-0.JPG",
                Latitude=39.743933, 
                Longitude=-105.020032
            },
            new FeaturedEventsSchema() {
                Event_Name="Maya: Hidden Worlds Revealed",
                Event_Date="Through August 24",
                Event_Location="Denver Museum of Nature & Science, 2001 Colorado Blvd.",
                Event_Cost="Non-member tickets start at $22",
                Link_1="http://www.denver.org/listings/Denver-Museum-of-Nature-Science/3888/",
                Link_2="http://www.denver.org/things-to-do/denver-arts-culture/maya/",
                Event_Description="Discover a hidden world at the Denver Museum of Nature & Science . The largest exhibition about the ancient Maya ever to be displayed in the United States, Maya: Hidden Worlds Revealed includes never-before-seen artifacts, hands-on activities, and immersive walk-in environments. Highlights include re-creations of an underground cave and a colorful, life-size frieze that once surrounded the top of El Castillo pyramid at Xunantunich in Belize. Explore the rise and decline of ancient cities, and learn how the Mayans' innovations (such as a 365-day calendar and incredible architecture) still impact our lives today.",
                Event_Image="http://www.denver.org/includes/content/images/media/1922013-705-114434-0.jpg",
                Latitude=39.7478398,
                Longitude=-104.942945
            },
            new FeaturedEventsSchema() {
                Event_Name="Chihuly",
                Event_Date="Through November 14",
                Event_Location="Denver Botanic Gardens, 1007 York St.",
                Event_Cost="Non-member exhibition tours start at $17",
                Link_1="http://www.denver.org/things-to-do/denver-arts-culture/chihuly/",
                Link_2="http://www.denver.org/listings/Denver-Botanic-Gardens/3655/",
                Event_Description="See the vibrant glass artwork of the renowned Dale Chihuly in the incomparable setting of the Denver Botanic Gardens . Chihuly’s sculptures – ranging from unique water features to a 30-foot neon tower – add bold colors and dramatic beauty to the Gardens’ 24-acre urban oasis. Don't miss some great hotel packages.",
                Event_Image="http://www.denver.org/includes/content/images/media/chihuly-2.png",
                Latitude=39.731971, 
                Longitude=-104.959954
            },
            new FeaturedEventsSchema() {
                Event_Name="Oh Heck Yeah",
                Event_Date="June 7-July 26",
                Event_Location="On Champa St., from the 16th Street Mall to 14th St.",
                Event_Cost="Free",
                Link_1="http://www.denver.org/includes/calendar-of-events/OH-HECK-YEAH/15569/",
                Link_2="",
                Event_Description="Step into a real-life video game! Downtown Denver will be transformed into an immersive street arcade during Oh Heck Yeah , a one-of-a-kind event. The arcade will be powered through a combination of Denver Theatre District's LED screens, projections, street art, social media, local media and a website.",
                Event_Image="http://www.denver.org/includes/content/images/media/3382013-705-132039.jpg",
                Latitude=39.7464868,
                Longitude=-104.9936024
            },
            new FeaturedEventsSchema() {
                Event_Name="First Friday Art Walks",
                Event_Date="July 4",
                Event_Location="Denver's Art Districts",
                Event_Cost="Free",
                Link_1="http://www.denver.org/listings/Art-District-on-Santa-Fe/4721/",
                Link_2="http://wwws.denver.org/about-denver/denver-neighborhoods/rino/",
                Event_Description="Visit with Denver's vibrant creative community at The Mile High City's art districts for the 4th, including Art District On Santa Fe , RiNo (River North Art District) and the Tennyson Street Cultural District . Galleries stay open late as art lovers enjoy live music, food and drink, and of course, plenty of great art.",
                Event_Image="http://www.denver.org/includes/content/images/media/CavaPic.jpg",
                Latitude=39.7320584,
                Longitude=-104.9983955
            }
        };

        public async Task<IEnumerable<FeaturedEventsSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<FeaturedEventsSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
