class SpaceAge(object):

    ORBITAL_PERIODS = [(k, v * 60 * 60 * 24 * 365.25) for k, v in (
        ('earth', 1.0),
        ('mercury', 0.2408467),
        ('venus', 0.61519726),
        ('mars', 1.8808158),
        ('jupiter', 11.862615),
        ('saturn', 29.447498),
        ('uranus', 84.016846),
        ('neptune', 164.79132)
    )]

    def __init__(self, seconds):
        self.seconds = seconds
        for planet, ratio in self.ORBITAL_PERIODS:
            result = lambda r=ratio: round(seconds / r, 2)
            setattr(self, 'on_' + planet, result)