if __name__ == '__main__':
    n = int(input())
    student_marks = {}
    for _ in range(n):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    query_name = input()

    for student in student_marks:
        if query_name == student: # find the query_name
            average_mark = sum(student_marks[query_name]) / 3 # find the average of the query_name's grades
            print('{0:.2f}'.format(average_mark)) # format and print to 2 decimal places
