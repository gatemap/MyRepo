# 실습1
# 남은 음료수를 확인하고 출력하는 함수
def printRemainDrink(drink_list) :
    print(f"남은 음료수 : {drink_list}\n")

# 입력받은 음료수가 있는지 확인하는 함수
def isDrink(drink, drink_list) :
    return drink in drink_list

# 음료수를 추가하는 함수
def addDrink(drink, drink_list) :
    if isDrink(drink, drink_list) :
        drink_list.insert(drink_list.index(drink), drink)
    else :
        drink_list.append(drink)

# 음료수를 제거하는 함수
def removeDrink(drink, drink_list) :
    drink_list.remove(drink)

def test1() :
    vending_machine = ['게토레이', '게토레이', '레쓰비', '레쓰비', '생수', '생수', '생수', '이프로']
    printRemainDrink(vending_machine)
    user_type = input("사용자 종류를 입력하세요 : \n1. 소비자\n2. 주인\n")

    # 사용자가 소비자인 경우
    if user_type == "1" or user_type == "소비자" :
        buy_drink = input("마시고 싶은 음료? ")
        # 입력받은 값이 리스트 안에 존재
        if isDrink(buy_drink, vending_machine) :
            print(f"{buy_drink} 드릴게요")
            removeDrink(buy_drink, vending_machine)
            printRemainDrink(vending_machine)
        else :
            print(f"{buy_drink} 지금 없네요")
    # 사용자가 주인인 경우
    elif user_type == "2" or user_type == "주인" :
        masterWork = input("할 일 선택 :\n1. 추가\n2. 삭제\n")
        printRemainDrink(vending_machine)
        if masterWork == "1" or masterWork == "추가" :
            add_drink = input("추가할 음료수? ")
            addDrink(add_drink, vending_machine)
            print("추가 완료")
            printRemainDrink(vending_machine)
        elif masterWork == "2" or masterWork == "삭제" :
            delete_drink = input("삭제할 음료수? ")
            if isDrink(delete_drink, vending_machine) :
                removeDrink(delete_drink, vending_machine)
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

# 필요한 함수들 선언
def functionPush(num, s) :
    s.append(num)

def functionPop(s) :
    if len(s) > 0 :
        print(s.pop())
    else :
        print('-1')
        
def functionSize(s) :
    print(len(s))
    
def functionEmpty(s) :
    if len(s) > 0 :
        print('1')
    else :
        print('0')

def functionTop(s) :
    if len(s) > 0 :
        print(s[-1])
    else :
        print('-1')

def test2() :    
    lines = int(sys.stdin.readline())
    stack = []
    # 입력받은 명령어
    for i in range(lines) :
        command = sys.stdin.readline().strip()
        if 'push' in command :
            command_push = command.split(' ')
            functionPush(command_push[1], stack)
        elif 'pop' in command :
            functionPop(stack)
        elif 'size' in command :
            functionSize(stack)
        elif 'empty' in command :
            functionEmpty(stack)
        elif 'top' in command :
            functionTop(stack)
        else :
            print("No contain command, readline = " + command)


# 실습3(피보나치 함수 만들기(재귀))
def test3() :
    num = int(input("입력 받을 피보나치 수 : "))
    print(f"F{num} = {fibonacci(num)}")


def fibonacci(n) :
    if n <= 2 :
        return 1
    else :
        return fibonacci(n-1) + fibonacci(n-2)


def main() :
    #test1()
    #test2()
    test3()


# __name__은 모듈의 이름을 담고 있는 파이썬 내장 변수이고, __main__은 최상위 코드가 실행되는 환경의 이름이다
if __name__ in "__main__" : 
    main()