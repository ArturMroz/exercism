#[derive(Debug)]
pub struct Duration(f64);

impl From<u64> for Duration {
    fn from(s: u64) -> Self {
        Duration(s as f64 / 60. / 60. / 24. / 365.25)
    }
}

pub trait Planet {
    const ORBITAL_PERIOD: f64;

    fn years_during(d: &Duration) -> f64 {
        d.0 / Self::ORBITAL_PERIOD
    }
}

macro_rules! planet {
    ($planet_name:ident, $orbital_period:expr) => {
        pub struct $planet_name;
        impl Planet for $planet_name {
            const ORBITAL_PERIOD: f64 = $orbital_period;
        }
    };
}

planet!(Earth, 1.0);
planet!(Mercury, 0.2408467);
planet!(Venus, 0.61519726);
planet!(Mars, 1.8808158);
planet!(Jupiter, 11.862615);
planet!(Saturn, 29.447498);
planet!(Uranus, 84.016846);
planet!(Neptune, 164.79132);
