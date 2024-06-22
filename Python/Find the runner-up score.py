if __name__ == '__main__':
    n = int(input())
    arr = list(map(int, input().split()))
    biggest = max(arr)
    runnerUp = 0;
    for i in range(1, n):
        if arr[i] < biggest and arr[i] > runnerUp:
            runnerUp = arr[i]
            
    print(runnerUp)
