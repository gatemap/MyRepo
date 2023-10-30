def main() :
    except_practice()

def except_practice() : 
    while True :
        try :
            num = int(input("정수를 입력해주세요 : "))
        except ValueError as msg :
            print(f"정수가 아님! 정수를 입력해주세요!\nError Message : {msg}")
        else :
            print(f"정수 입력 완료. 입력된 정수 : {num}")
            break
        
if __name__ == '__main__' :
    main()