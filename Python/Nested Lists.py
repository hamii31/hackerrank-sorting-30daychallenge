students = []
for i in range(1, int(input())+1):
    name = input()
    score = float(input())
    students.append([name, score])

second_lowest_grade = sorted({s[1] for s in students})[1] # get the second worse score

# sort alphabetically
students.sort()

for student in students:
    if student[1] == second_lowest_grade: # if the score is equal to the second worse, print the name
        print(student[0])
