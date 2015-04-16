//
//  A360UObjectCache.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/15/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360UObjectCache.h"

@implementation A360UObjectCache

+ (instancetype)sharedInstance {
    static A360UObjectCache *sharedInstance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[self alloc] init];
    });
    return sharedInstance;
}

- (id)init {
    self = [super init];
    if (self) {
        _references = [[NSMutableDictionary alloc] init];
    }
    return self;
}

@end

@implementation NSObject (A360UOwnershipAdditions)

- (NSString *)a360u_referenceKey {
    return [NSString stringWithFormat:@"%p", (void *)self];
}

@end