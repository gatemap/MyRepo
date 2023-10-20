import time

'''
#실습 1
ran = int(input("어디까지 계산할까요? "))
result = 0

for i in range(ran+1) :
    result += i
    
print(f"{result}")

#번외
result = 0
for i in range(ran+1) :
    if i % 2 == 1 :
        result += i
        
print(f"홀수만 더한 값 : {result}")


#실습 2
countDown = int(input("몇 초? "))
for i in range(countDown, 0, -1) :
    # 1초에 한번씩 일시정지
    time.sleep(1)
    print(f"{i} ", end='')
print("발사!!!")


#실습 3
multipli = int(input("몇 단을 출력할까요? "))
for i in range(1, 10) : 
    print(f"{multipli} * {i} = {multipli * i}")
    


#실습 4
starType = input("별 찍기 타입을 고르세요.\n1. 좌측 정렬\t2. 우측 정렬\t3. 중앙 정렬 : ")
starLine = int(input("몇 줄? "))
line = 1
while starLine + 1 > line :
    # 좌측 정렬의 경우
    if starType == "1" :
        print("*" * line)
    # 우측 정렬의 경우
    elif starType == "2" :
        print(" " * (starLine - line) + "*" * line)
    elif starType == "3" :
        print(" " * (starLine - line) + "*" * (line* 2 - 1) + " " * (starLine - line))
    else :
        print("Error")
        
    line += 1
        
'''


#실습 5
inputNumList = input("숫자 여러 개 입력 ")
inputNumList = inputNumList.split(" ")
print(inputNumList)
numList = list(map(int, inputNumList))
print(f"가장 큰 값 : {max(numList)}")
print(f"가장 작은 값 : {min(numList)}")
numList.remove(max(numList))
numList.remove(min(numList))
print(numList)
avg = 0.0
avgCount = 0
for i in numList :
    avg += i
    avgCount += 1

avg = float(avg/avgCount)

print(f"나머지 값의 평균 값 : {avg}, {avgCount}")
    