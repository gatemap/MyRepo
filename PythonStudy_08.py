# 파일 입출력 연습
def fileInOut() :
    f1 = open("./test2.txt", "r")
    print(f1.read())
    
    f1.seek(0)
    print(f1.tell())
    
    context = f1.readlines()
    print(context)
    
    f1.close()
    
    
from pathlib import Path


# 실습 1, 2
def practice_1() :
    '''
    file_path = Path("memberInfo.txt")    
    members = 0
    file = ''
    
    # 이미 파일이 존재하면 내용을 다 날린다
    if file_path.exists() :
            file = open("./memberInfo.txt", "w")
            file.write('')
            file.close()
            
    while members < 3 :
        name = input("이름 : ")
        password = input("암호 : ")

        if file_path.exists() :
            file = open("./memberInfo.txt", "a")
            file.write(f"{name}, {password}\n")
            file.close()
        else :
            file = open("./memberInfo.txt", "w")
            file.write(f"{name}, {password}\n")
            file.close()
            
        members += 1
    '''
    file = open("./memberInfo.txt", "r")
    member_info = file.read()
    print(file.read())
    file.close()
    
    # 이름, 비밀번호 입력받기
    input_name = input("이름을 입력하세요 : ")
    input_password = input("비밀번호를 입력하세요 : ")
    
    # 사용자들 이름, 비밀번호를 한 줄로 리스트화
    member_info_list = member_info.split('\n')
    # 마지막 엔터가 리스트로 들어간 것 제거
    member_info_list.pop()
    member_info_detail = {}
    
    # 사용자 한 명에 대해서 이름과 비밀번호를 key : value로 저장
    for data in member_info_list :
        detail = data.split(', ')
        member_info_detail[detail[0]] = detail[1]
    
    # key값과 value가 함께 동일한지 체크
    login_success = False
    for key in member_info_detail :
        if input_name == key and input_password == member_info_detail[key] :
            login_success = True
            break

    print("로그인 성공" if login_success else "로그인 실패")
    
def main() :
    #fileInOut()
    practice_1()
    
    
if __name__ == '__main__' :
    main()