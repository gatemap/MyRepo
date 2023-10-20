'''

shop = ["반팔", "청바지", "이어폰", "키보드"]

#인덱싱
print(shop[0])


#슬라이싱
print(shop[0:2])

#리스트 안에 리스트에서 인덱싱
my_shop = ["반팔", "청바지", "이어폰", ["무선 키보드", "유선 키보드", "기계식 키보드"]]
print(my_shop[3])
print(my_shop[-1])
print(my_shop[2:4])


#리스트 함수 - 추가/삭제

shop = ["a", "b", "c", "d"]

#추가
shop.append("e")
print(shop)

#삭제
shop.remove("b")
print(shop)


#실습1

print()
rainbow = ['red', 'orange', 'yellow', 'green', 'blue', 'indigo', 'purple']

print(rainbow[1])
rainbow.sort()
print(rainbow)
rainbow.append('white')
print(rainbow)
del rainbow[2:6]
print(rainbow)



# 실습2
print()
num = input("숫자를 입력하세요. ")

if int(num)%2==0 :
    print("짝수 입니다.")
else :
    print("홀수 입니다.")


# 실습3
print()
score = float(input("점수를 입력하세요."))

if score >= 90 :
    print('A')
elif 80 <= score < 90 :
    print('B')
elif 70 <= score < 80 :
    print('C')
elif 60 <= score < 70 :
    print('D')
else :
    print('E')

'''

# 실습4
print()
age = int(input("나이를 숫자로 입력해주세요. "))
payment = input("결제 방법을 입력해주세요. (\'카드\' 또는 \'현금\'만 입력) ")
pay = 0
if payment == "현금" :
    if age < 8 or age >= 75:
        pay = 0
    elif 8 <= age < 14 : 
        pay = 450
    elif 14 <= age <20 :
        pay = 1000
    elif 20 <= age <75 :
        pay =1300
elif payment == "카드" :
    if age < 8 or age >= 75:
        pay = 0
    elif 8 <= age < 14 :
        pay = 450
    elif 14 <= age <20 :
        pay = 720
    elif 20 <= age <75 :
        pay =1200
else :
    print("카드 혹은 현금으로 입력하지 않았습니다.")

print("{0}세의 {1} 요금은 {2}원 입니다.".format(age, payment, pay))
#print(f"{age}세의 {payment} 요금은 {pay}원 입니다.") // 파이썬 3.6버전 이상부터 사용 가능한 기능
