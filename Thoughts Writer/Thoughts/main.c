#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#define buff 2048
#define obsidian "C:\\Users\\Patrik\\Documents\\Obsidian Vault\\thoughtsJournal.md"

void writeTime(FILE *file) {
    struct tm newtime;
    __time64_t long_time;
    char timebuf[26];
    errno_t err;

    // Get time as 64-bit integer.
    _time64(&long_time);
    // Convert to local time.
    err = _localtime64_s(&newtime, &long_time);
    if (err)
    {
        printf("Invalid argument to _localtime64_s.");
        exit(1);
    }

    // Convert to an ASCII representation.
    err = asctime_s(timebuf, 26, &newtime);
    if (err)
    {
        printf("Invalid argument to asctime_s.");
        exit(1);
    }
    fprintf(file, "%.19s\n", timebuf);
}


int saveThoughts(int n){
    errno_t err;
    FILE* file = NULL;
    char* str = (char*)malloc(buff * sizeof(char));
    if (str == 0) {
        fprintf(stderr, "Memory allocation failed\n");
        return 1;
    }
    switch (n) {
    case 1:
        printf("Enter your thoughts: (date not saved)\n");
        break;
    case 2:
        printf("Enter your thoughts: (date saved)\n");
        break;
    case 3:
        printf("Enter your thoughts: (not sure what do implement)\n");
        break;
    default:
        break;
    }
    fgets(str, buff, stdin);

    err = fopen_s(&file, obsidian, "a+");
    if (err != 0) {
        fprintf(stderr, "Could not open file\n");
        free(str);
        return 1;
    }
    switch (n) {
    case 1:
        break;
    case 2:
        writeTime(file);
        break;
    default:
        break;
    }
    fprintf(file, "\n%s\n\n", str);
    printf("Your thoughts have been saved to obsidian\n");
    fclose(file);
    free(str);
    return 0;
}

int main(){
    int status = 0;
    int n;
    while (status == 0)
    {
        do {
        printf("Enter type of thought: (1-3):\n");
        int err = scanf("%d", &n);
        getchar();
        if (err != 1) {
            fprintf(stderr, "Invalid input\n");
            return 1;
        }
        } while (!(n >= 1 && n <= 3));
        status = saveThoughts(n);
    }

	return 0;
}