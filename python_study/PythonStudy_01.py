import keyword
from datetime import datetime

# 키워드 종류를 표시합니다
'''
print(keyword.kwlist)

print("Hello", "world")
print("Hello", "World", sep="")
print("피곤", 10000)
print("프린팅", end="")
print("test")



print("pyc 디컴파일 알려주세요\n\n\n\n\n")
# Python에서의 주석은 '#'을 사용함

print("|\_\|\n","|q p|\t/}\n", "(  0  )\"\"\"\\\n", "|\"^\"`\t|\n", "||_/=\\__|", sep="")

#
print("\n안녕"+"반가워")
print("!"*10)

print()
print(len("바나나"))
print("banana".count('a'))

#
print()
ive = "원영 유진 레이"
print(ive.split(' '))

email = "spacernet@naver.com"
print(email.split('@'))

#
print()
song = input("최애 노래는? ")
print(song)

print(type(song))

#
print()
str1 = input("str1 (정수 값): ")
int1 = int(str1)
print(str1, int1)
print(type(str1), type(int1))

str2 = input("str2 (실수 값) : ")
float2 = float(str2)
print(str2, float2)
print(type(str2), type(float2))


#
print()
name = input("이름을 입력하세요. ")
age = input("나이를 입력하세요. ")
print("안녕하세요!"+name+"("+age+"세)\n")


name = input("이름을 입력하세요. ")
birthYear = input("태어난 년도를 입력하세요. ")
year = input("올해 년도를 입력하세요. ")
print("올해는" + year + ", " + name + "님의 나이는"+ str(int(year) - int(birthYear)) +"세 입니다.")


firstNum = input()
secondNum = input()
firstNum.strip()
secondNum.strip()
print("---------------------------")
length = len(firstNum) if int(firstNum) < int(secondNum) else len(secondNum)
for i in range(length) :
    if int(firstNum) >= int(secondNum) :
        print(int(firstNum) * int(secondNum[-1-i]) * 10 ** i)
    else :
        print(int(secondNum) * int(firstNum[-1-i]) * 10 ** i)
print("---------------------------")
print(int(firstNum) * int(secondNum))

'''

# 번외 문제편
print()
date1 = datetime.strptime(input("yyyy-mm-dd 형태로 입력하세요. "), '%Y-%m-%d')
date2 = datetime.strptime(input("yyyy-mm-dd 형태로 입력하세요. "), '%Y-%m-%d')

print(abs(date1-date2).days)
