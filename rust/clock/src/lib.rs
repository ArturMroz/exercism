use std::fmt;

#[derive(PartialEq, Debug)]
pub struct Clock {
    hours: i32,
    minutes: i32,
}

impl Clock {
    pub fn new(hours: i32, minutes: i32) -> Self {
        let overflow_hours = minutes / 60;

        let mut _minutes = minutes % 60;
        let mut _hours = (hours + overflow_hours) % 24;

        if _minutes < 0 {
            _minutes += 60;
            _hours -= 1;
        }

        if _hours < 0 { _hours += 24 }

        Self {
            hours: _hours,
            minutes: _minutes,
        }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Clock::new(self.hours, self.minutes + minutes)
    }
}

impl fmt::Display for Clock {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "{:02}:{:02}", self.hours, self.minutes)
    }
}
