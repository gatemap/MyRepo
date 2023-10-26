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



class Acconut :
    num_accounts = 0
    
    def __init__(self, name) :
        self.name = name
        Acconut.num_accounts += 1
        
    def __del__(self) :
        Acconut.num_accounts -= 1
        
        
john = Acconut("John")
bear = Acconut("Bear")

print(john.num_accounts)
print(bear.num_accounts)
print(Acconut.num_accounts)



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



# 접근제어 연습



# 실습 1
class Calculation :
    def __init__(self, a, b):
        self.__a = a
        self.__b = b
    
    def Add(self) :
        return self.__a + self.__b
    
    def Sub(self) :
        return self.__a - self.__b
    
    def Mul(self) :
        return self.__a * self.__b
    
    def Div(self) :
        return self.__a / self.__b
    

result = Calculation(10, 5)
print(f"더한 값 = {result.Add()}, 뺀 값 = {result.Sub()}, 곱한 값 = {result.Mul()}, 나눈 값 = {result.Div()}")


# 실습2
class Supermarket :
    def __init__(self, location, name, product) :
        self.__location = location
        self.__name = name
        self.__product = product
        self.__customer = 0
        
    def printLocation(self) :
        print(self.__location)
    
    def changeCategory(self, p) :
        self.__product = p
        
    def showList(self) :
        print(self.__product)
        
    def enterCustomer(self) :
        self.__customer += 1
        
    def showInfo(self) :
        print(f"{self.__name}, {self.__location}, {self.__product}, {self.__customer}")

# 실습3
class Country :
    def _printDefinition(self) :
        print("국가는 영토와 국민이 있으며 주권을 갖고 있는 것을 의미해요.")
        

class Korea(Country) :
    def printInfo(self) :
        self._printDefinition()
        print("대한민국은 국가입니다.")
        
        
korea = Korea()
korea.printInfo()


# 실습4
class Calculator :
    def __init__(self) :
        self.value = 100
        
    def sub(self, value) :
        self.value -= value
        

class MinLimitCalculator(Calculator) :
    def sub(self, value):
        self.value = self.value - value if self.value - value >= 0 else 0
    
cal = MinLimitCalculator()
cal.sub(20)
cal.sub(90)
print(cal.value)

'''

import random
import string

# 실습5
class Creature :
    def __init__(self, hp, attack, deffence) :
        self._hp = hp
        self._attack = attack
        self._deffence = deffence
        
    # 공격 method
    def attack(self) :
        pass
    
    # 피격 method
    def _hit(self) : 
        
        # 체력이 0 이하가 되면 사망처리
        if self.hp <= 0 :
            self._die()

    # 사망 method
    def _die(self) :
        pass

class Player(Creature) :
        def __init__(self, hp, attack, deffence):
             super().__init__(hp, attack, deffence)
             self.__exp = 0
             self.__level = 1
        
        def playerInput(self, dir, action) :
            if action == 'move' :
                if dir == 'left' :
                    self.__x -= -1
                elif dir == 'right' :
                    self.__x += 1
                    
            elif action == 'attack' :
                self.attack()
                
            elif action == 'jump' : 
                self.__y = 0
                
                while self.__y < 1 :
                    self.__y += 0.0001
                    
                while self.__y >= 0 :
                    self.__y -= 0.0009
                    
            elif action == 'get' :
                self.getItem()
                
        
        def __playerLevelUp(self) :
            self._attack += random.randrange(1, 10)
            self._deffence += random.randrange(1, 10)
            self.__exp = 0
            self.__level += 1
            
        def attack(self):
            super().attack()
            
        def _hit(self):
            super()._hit()
            
            if self.hp <= 0 :
                self._die()
            
        def _die(self):
            # 사망 시 경험치 감소, 보유 경험치보다 감소 경험치가 많으면 0으로 만든다
            self.__exp = self.__exp - (10 * self.__level) if self.__exp - (10 * self.__level) >= 0 else 0

        # 아이템 줍기
        def getItem(self) :
            pass
            

class Monster(Creature) :
    def __init__(self, hp, attack, deffence):
        super().__init__(hp, 0, 0)
        self.__statusInit()

    # 몬스터 초기화        
    def __statusInit(self) :
        self._attack = random.randrange(3, 8)
        self._deffence = random.randrange(3, 8)
        self.__name = ''.join(random.choice(string.ascii_letters) for _ in range(6))
        
    def attack(self):
        super().attack()
        
    def _hit(self):
        super()._hit()
        
        if self._hp <= 0 :
            self._die()
        
    def _die(self):
        pass
    
    
# 실습6
class Animal :
    def PlaySound(self) :
        print("나의 울음 소리는~", end = '')
        
        
class Dog(Animal) :
    def PlaySound(self):
        super().PlaySound()
        print("RR")
        
        
pero = Dog()
pero.PlaySound()
