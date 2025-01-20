from functools import reduce

def concat(x, y):
    return y(x)

def tap(message):
    def pprint(x):
        print(f'{message}: {x}')
        return x
    return pprint

def reducer(transform_functions, iv):
    return reduce(concat, transform_functions, iv)


def transducer(transformations: list, numbers: list):
    return [reducer(transformations, x) for x in numbers]


def transformer(value, transformations):

    for transformation in transformations:
        value = transformation(value)
    return value

def transducer2(transformations: list, ll: list):                       
    return [transformer(x, transformations) for x in ll]