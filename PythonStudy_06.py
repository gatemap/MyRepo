'''
class Movie :
    # field
    name = ''
    
    #methond
    def printMsg(msg) :
        print(msg)
        
    # 이 함수는 객체로 호출 할 수 없다
    def printing() :
        print("printing~")
        
    # self 사용, method 선언
    def modify (self, movie) :
        self.name = movie
        
movie1 = Movie()
movie2 = Movie()

# method 호출
Movie.printMsg('print 하기')
Movie.printing()
movie1.modify('name1')
movie2.modify('name2')
 
print(movie1.name)
print(movie2.name)



class Movie :
    count = 0
    
    def __init__(self, title, audience):
        self.title = title
        self.audience = audience
        Movie.count += 1

movie1 = Movie("Bossbaby", 100)
movie2 = Movie("Bossbaby2", 200)

print(movie1.title, movie1.audience, movie1.count)
print(movie2.title, movie2.audience, movie2.count)
print(Movie.count)

'''

# 객체 관련 실습
class Person :
    def __init__(self, name, age) :
        self.name = name
        self.age = age
        
    def introduce(self) :
        print(f"제 이름은 {self.name}이고, 나이는 {self.age}입니다.")

person1 = Person("Alice", 30)
person2 = Person("Bob", 25)

person1.introduce()
person2.introduce()

