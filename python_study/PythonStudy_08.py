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
            file = open("./memberInfo.txt", "w", encoding='EUC-KR')
            file.write('')
            file.close()
            
    while members < 3 :
        name = input("이름 : ")
        password = input("암호 : ")

        if file_path.exists() :
            file = open("./memberInfo.txt", "a", encoding='EUC-KR')
            file.write(f"{name}, {password}\n")
            file.close()
        else :
            file = open("./memberInfo.txt", "w", encoding='EUC-KR')
            file.write(f"{name}, {password}\n")
            file.close()
            
        members += 1
    '''
    
    file = open("./memberInfo.txt", "r", encoding='EUC-KR')
    member_info = file.readlines()
    # 사용자들 이름, 비밀번호를 한 줄로 저장
    member_info = [i.strip() for i in member_info]
    file.close()
    
    print(member_info)
    
    # 이름, 비밀번호 입력받기
    input_name = input("이름을 입력하세요 : ")
    input_password = input("비밀번호를 입력하세요 : ")
    
    # 로그인 성공/실패 체크
    login_success = False
    for i in member_info :
        info = i.split(', ')
        if info[0] == input_name and info[1] == input_password :
            login_success = True
            break

    print("로그인 성공" if login_success else "로그인 실패")
    
    if login_success :
        tel_num = input("전화번호를 입력하세요 : ")
        
        member_tel_path = Path("member_tel.txt")
        
        if member_tel_path.exists() :
            file = open("./member_tel.txt", "r", encoding='EUC-KR')
            members_tel_info = file.readlines()
            file.close()
            
            # 이미 존재하는 회원 데이터인지 조회
            memberExist = False
            for i in range(len(members_tel_info)) :
                info = members_tel_info[i].split(', ')
                if info[0] == input_name :
                    memberExist = True
                    # 수정된 정보로 변경(수정)
                    members_tel_info[i] = f"{input_name}, {tel_num}\n"
                    break
            
            # 사용자 이름이 이미 존재하는 경우(수정)
            if memberExist :
                with open("./member_tel.txt", "w", encoding='EUC-KR') as file :
                    # 한 번 싹 날리고
                    file.write('')
                    # 갱신한 데이터 삽입
                    for i in members_tel_info :
                        file.write(i)
                
            # 신규 사용자의 경우
            else :
                with open("./member_tel.txt", "a", encoding='EUC-KR') as file :
                    file.write(f"{input_name}, {tel_num}\n")
        
        # 파일이 없는 경우 그냥 새로 기록
        else :
            with open("./member_tel.txt", "w", encoding='EUC-KR') as file :
                file.write(f"{input_name}, {tel_num}\n")
            
def main() :
    #fileInOut()
    practice_1()
    
    
if __name__ == '__main__' :
    main()