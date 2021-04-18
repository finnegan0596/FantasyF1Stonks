using System;

namespace FormulaOneStonks.Models
{
    public class Player
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string team_name { get; set; }
        public string position { get; set; }
        public int position_id { get; set; }
        public string position_abbreviation { get; set; }
        public float price { get; set; }
        public Current_Price_Change_Info current_price_change_info { get; set; }

        public int sentiment
        {
            get
            {
                return current_price_change_info.probability_price_down_percentage > current_price_change_info.probability_price_up_percentage
                    ? -current_price_change_info.probability_price_down_percentage
                    : current_price_change_info.probability_price_up_percentage;
            }
        }

        public string type
        {
            get
            {
                return is_constructor ? "Constructor" : "Driver";
            }
        }

        public double points_per_million
        {
            get
            {
                return Math.Round((season_score / price), 2);
            }
        }

        public object status { get; set; }
        public bool injured { get; set; }
        public object injury_type { get; set; }
        public bool banned { get; set; }
        public object ban_type { get; set; }
        public Streak_Events_Progress streak_events_progress { get; set; }
        public float chance_of_playing { get; set; }
        public string team_abbreviation { get; set; }
        public float weekly_price_change { get; set; }
        public int team_id { get; set; }
        public Headshot headshot { get; set; }
        public string known_name { get; set; }
        public Jersey_Image jersey_image { get; set; }
        public int score { get; set; }
        public object humanize_status { get; set; }
        public int? shirt_number { get; set; }
        public string country { get; set; }
        public bool is_constructor { get; set; }
        public float season_score { get; set; }
        public Driver_Data driver_data { get; set; }
        public Constructor_Data constructor_data { get; set; }
        public string born_at { get; set; }
        public Season_Prices[] season_prices { get; set; }
        public int num_fixtures_in_gameweek { get; set; }
        public bool deleted_in_feed { get; set; }
        public bool has_fixture { get; set; }
        public string display_name { get; set; }
        public string external_id { get; set; }
        public Profile_Image profile_image { get; set; }
        public Misc_Image misc_image { get; set; }

        public double price_change { // sometimes the api returns the price in the weekly price change. IDK why. Workaround
            get 
            {
                return weekly_price_change == price ? 0 : Math.Round(weekly_price_change, 1); ;    
            } 
        }
        #region css

        public string sentiment_class
        {
            get
            {
                if (sentiment == 0)
                    return null;
                if (sentiment <= -50)
                    return "table-bad";
                if (sentiment >= 50)
                    return "table-good";
                return null;
            }
        }

        public string price_change_class
        {
            get
            {
                if (price_change < 0)
                    return "table-bad";
                if (price_change > 0)
                    return "table-good";
                return null;
            }
        }


        public string qualification_streak_class
        { 
            get
            {
                bool isParseSuccess = Int32.TryParse(streak_events_progress.top_ten_in_a_row_qualifying_progress, out int streak);
                if (is_constructor && isParseSuccess && streak == 2)
                    return "table-good";
                if(!is_constructor && isParseSuccess && streak == 4)
                    return "table-good";
                return null;
            }
        }

        public string race_streak_class
        {
            get
            {
                bool isParseSuccess = Int32.TryParse(streak_events_progress.top_ten_in_a_row_race_progress, out int streak);
                if (is_constructor && isParseSuccess && streak == 2)
                    return "table-good";
                if (!is_constructor && isParseSuccess && streak == 4)
                    return "table-good";
                return null;
            }
        }

        #endregion css
    }
}