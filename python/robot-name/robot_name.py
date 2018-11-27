import random
import string
from time import time


class Robot(object):
    name_list = []

    def __init__(self):
        self.reset()

    def reset(self):
        random.seed(time())
        name = self._generate_name()
        if name not in self.name_list:
            self.name_list.append(name)
            self.name = name
        else:
            self.reset()

    def _generate_name(self):
        name = ""
        for _ in range(2):
            name += random.choice(string.ascii_uppercase)
        for _ in range(3):
            name += random.choice(string.digits)

        return name
