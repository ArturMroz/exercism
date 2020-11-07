use std::fmt;

const MINUTES_IN_HOUR: i32 = 60;
const MINUTES_IN_DAY: i32 = 24 * MINUTES_IN_HOUR;

#[derive(PartialEq, Debug)]
pub struct Clock {
    minutes: i32,
}

impl Clock {
    pub fn new(hours: i32, minutes: i32) -> Self {
        let mut _minutes = (hours * MINUTES_IN_HOUR + minutes) % MINUTES_IN_DAY;

        if _minutes < 0 { _minutes += MINUTES_IN_DAY };

        Self {
            minutes: _minutes,
        }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Clock::new(0, self.minutes + minutes)
    }
}

impl fmt::Display for Clock {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "{:02}:{:02}", self.minutes / 60, self.minutes % 60)
    }
}
