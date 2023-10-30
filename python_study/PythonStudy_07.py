import python_study.calc_module as calc_module

def modulePractice() :

    #모듈명.함수명
    print(calc_module.add(2, 3))
    print(calc_module.sub(2, 3))
    print(calc_module.multiply(2, 3))
    print(calc_module.divide(2, 3))

import random as rnd

def practice_1() :
    
    rand_int_list = []

    for i in range(4) :
        rand_int_list.append(rnd.randint(1, 100))

    rand_int_list.sort()
    print(rand_int_list)
    
    
def practice_2() :
    random_int = rnd.randint(1, 10)
    answer = 0
    while random_int != answer :
        answer = int(input("숫자를 맞춰보세요 : "))
        
        if random_int != answer :
            print("땡!")
        
    
    print(f"맞았어요! 랜덤 숫자는 {random_int}입니다")
    
    
def practice_3() :
    lotto_num_list = []
    
    while len(lotto_num_list) < 6 :
        lotto_num = rnd.randint(1, 45)
        if lotto_num not in lotto_num_list :
            lotto_num_list.append(lotto_num)
        
        # 중복 없이 바로 뽑아낼 수 있는 방법도 있음  
        # lotto_num_list = rnd.sample(range(1, 45), 6)
    
    print(lotto_num_list)
    
def main() :
    #modulePractice()
    #practice_1()
    #practice_2()
    practice_3()
    
    
if __name__ == '__main__' :
    main()