# 실습1
vending_machine = ['게토레이', '게토레이', '레쓰비', '레쓰비', '생수', '생수', '생수', '이프로']

# 남은 음료수를 확인하고 출력하는 함수
def printRemainDrink(drink_list) :
    print(f"남은 음료수 : {drink_list}\n")

# 입력받은 음료수가 있는지 확인하는 함수
def isDrink(drink) :
    return drink in vending_machine

# 음료수를 추가하는 함수
def addDrink(drink) :
    if isDrink(drink) :
        vending_machine.insert(vending_machine.index(drink), drink)
    else :
        vending_machine.append(drink)

# 음료수를 제거하는 함수
def removeDrink(drink) :
    vending_machine.remove(drink)


printRemainDrink(vending_machine)
user_type = input("사용자 종류를 입력하세요 : \n1. 소비자\n2. 주인\n")

# 사용자가 소비자인 경우
if user_type == "1" or user_type == "소비자" :
    buy_drink = input("마시고 싶은 음료? ")
    # 입력받은 값이 리스트 안에 존재
    if isDrink(buy_drink) :
        print(f"{buy_drink} 드릴게요")
        removeDrink(buy_drink)
        printRemainDrink(vending_machine)
    else :
        print(f"{buy_drink} 지금 없네요")
# 사용자가 주인인 경우
elif user_type == "2" or user_type == "주인" :
    masterWork = input("할 일 선택 :\n1. 추가\n2. 삭제\n")
    print(f"남은 음료수 : {vending_machine}\n")
    if masterWork == "1" or masterWork == "추가" :
        add_drink = input("추가할 음료수? ")
        addDrink(add_drink)
        print("추가 완료")
        printRemainDrink(vending_machine)
    elif masterWork == "2" or masterWork == "삭제" :
        delete_drink = input("삭제할 음료수? ")
        if isDrink(delete_drink) :
            removeDrink(delete_drink)
            print("삭제 완료")
            printRemainDrink(vending_machine)
        else :
            print(f"{delete_drink} 지금 없네요")
    else :
        print("Error")
# 사용자(1)도 아니고 주인(2)도 아닌 경우의 값이 들어온 경우
else :
    print("누구세요?")
    

# 실습2
# 백준 10828번 문제
import sys

lines = int(sys.stdin.readline)
stack = []

# 필요한 함수들 선언
def functionPush(num) :
    stack.append(num)

def functionPop() :
    if len(stack) > 0 :
        print(stack.pop())
    else :
        print('-1')
        
def functionSize() :
    print(len(stack))
    
def functionEmpty() :
    if len(stack) > 0 :
        print('1')
    else :
        print('0')

def functionTop() :
    if len(stack) > 0 :
        print(stack[0])
    else :
        print()

# 입력받은 명령어
for i in range(lines) :
    command = sys.stdin.readline
    if command in 'push' :
        command_push = command.split(' ')
        functionPush(command_push[1])
    elif command == 'pop' :
        functionPop()
    elif command == 'size' :
        functionSize()
    elif command == 'empty' :
        functionEmpty()
    elif command == 'top' :
        functionTop()