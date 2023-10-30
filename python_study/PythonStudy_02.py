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

if payment == "현금" or payment == "카드" :
    print("{0}세의 {1} 요금은 {2}원 입니다.".format(age, payment, pay))
#print(f"{age}세의 {payment} 요금은 {pay}원 입니다.") // 파이썬 3.6버전 이상부터 사용 가능한 기능




# 과제 1
vending_machine = ['게토레이', '레쓰비', '생수', '이프로']
print(f"음료수 리스트 : {vending_machine}")

for i in range(2) : 
    print("==================RESTART")
    drink = input("마시고 싶은 음료? ")
    if drink in vending_machine : 
        print(f"{drink} 드릴게요")
    else :
        print(f"{drink} 지금 없네요")
        
'''
# 과제 2
vending_machine = ['게토레이', '게토레이', '레쓰비', '레쓰비', '생수', '생수', '생수', '이프로']
print(f"남은 음료수 : {vending_machine}\n")

userType = input("사용자 종류를 입력하세요 : \n1. 소비자\n2. 주인\n")

# 사용자가 소비자인 경우
if userType == "1" or userType == "소비자" :
    buyDrink = input("마시고 싶은 음료? ")
    # 입력받은 값이 리스트 안에 존재
    if buyDrink in vending_machine :
        print(f"{buyDrink} 드릴게요")
        vending_machine.pop(vending_machine.index(buyDrink))
        print(f"남은 음료수 : {vending_machine}")
    else :
        print(f"{buyDrink} 지금 없네요")
# 사용자가 주인인 경우
elif userType == "2" or userType == "주인" :
    masterWork = input("할 일 선택 :\n1. 추가\n2. 삭제\n")
    print(f"남은 음료수 : {vending_machine}\n")
    if masterWork == "1" or masterWork == "추가" :
        addDrink = input("추가할 음료수? ")
        # 추가할 음료가 리스트에 있는 경우에는 해당 위치에 insert 해주고
        if addDrink in vending_machine :
            vending_machine.insert(vending_machine.index(addDrink), addDrink)
        # 추가할 음료가 리스트에 없는 경우는 마지막에 append 해준다
        else :
            vending_machine.append(addDrink)
        print("추가 완료")
        print(f"남은 음료수 : {vending_machine}")
    elif masterWork == "2" or masterWork == "삭제" :
        deleteDrink = input("삭제할 음료수? ")
        if deleteDrink in vending_machine :
            vending_machine.remove(deleteDrink)
            print("삭제 완료")
            print(f"남은 음료수 : {vending_machine}")
        else :
            print(f"{deleteDrink} 지금 없네요")
    else :
        print("Error")
# 사용자(1)도 아니고 주인(2)도 아닌 경우의 값이 들어온 경우
else :
    print("누구세요?")